using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gamemonitor : MonoBehaviour
{
    struct MoneySubtraction
    {

        public string Reason;
        public float amount;
        public MoneySubtraction(string s, float i)
        {
            Reason = s;
            amount = i;
        }
    }
    List<MoneySubtraction> MoneyLost = new List<MoneySubtraction>();

    const int INITIAL_QUESTION = 1;
    const int COURT_OUTCOME = 2;
    const int FINAL_MONEY_SCENE = 3;
    const int RESTART_GAME = 4;

    const int NEW_BIKE_COST = 500;

    const int MAX_HOSPITAL_BILL = 650;
    const int MAX_BUILDING_REPAIRS = 1000;

    BasePlayer BP;

    float iVel;
    public string Vel;
    public string Money;
    public string ChanceOfWinning;


    bool hitACar = false;

    int s_width, s_height;

    bool courtDecided;
    bool courtDecision; //true = won, false = lost
    int decisionChance;
    int courtState;
    static int GoldAmount = 0;
    bool inCourt;
    float VelocityOnDeath;
    float VelocityRatio;

    void Start()
    {
        BP = GameObject.Find("Player").GetComponent<BasePlayer>();
        inCourt = false;
        courtDecided = false;
        s_width = Screen.width;
        s_height = Screen.height;
        decisionChance = 100;
        VelocityRatio = 0.0f;

        AudioListener[] myListeners = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
        foreach (AudioListener thisListener in myListeners)
        {
            thisListener.enabled = false;
        }

    }
    void OnGUI()
    {
        //fuck the new unity gui.
        if (!inCourt)
        {
            GetNewStats();
            string ds = "";
            
            ds += "Speed = " + Mathf.Floor((BP.movement.velocity * 30)).ToString() + "\n";
            ds += "Money = " + GoldAmount.ToString() + "\n";
            if (instance == this)
                GUI.Box(new Rect(10, 10, 200, 50), ds);
        }
        else
        {
            //BP = GameObject.Find("Player").GetComponent<BasePlayer>();
            if (courtState == INITIAL_QUESTION)
            {
                MoneyLost.Clear();
                if (!hitACar)
                {
                    courtState = FINAL_MONEY_SCENE;
                    MoneyLost.Add(new MoneySubtraction("Bike Repairs", -(NEW_BIKE_COST * VelocityRatio)));
                    MoneyLost.Add(new MoneySubtraction("Hospital Bills", -(MAX_HOSPITAL_BILL * VelocityRatio)));
                    MoneyLost.Add(new MoneySubtraction("Building Repairs", -(MAX_HOSPITAL_BILL * VelocityRatio)));
                }
                else
                {
                    GUI.Box(new Rect(s_width / 2 - 300, s_height / 2 - 50, 600, 100), "Your injuries were not fatal, \nwould you like to take the car driver to court for a chance to cover your medical bills. \nThis will cost an additional $600 and you have a " + ChanceOfWinning + " % chance of winning.");
                    if (GUI.Button(new Rect(s_width / 2 - 110, s_height / 2 + 60, 100, 50), "Yes"))
                    {
                        courtState = COURT_OUTCOME;
                        MoneyLost.Add(new MoneySubtraction("Bike Repairs", -(NEW_BIKE_COST * VelocityRatio)));
                        MoneyLost.Add(new MoneySubtraction("Hospital Bills", -(MAX_HOSPITAL_BILL * VelocityRatio)));
                    }
                    else if (GUI.Button(new Rect(s_width / 2 + 10, s_height / 2 + 60, 100, 50), "No"))
                    {
                        courtState = FINAL_MONEY_SCENE;
                        MoneyLost.Add(new MoneySubtraction("Bike Repairs", -(NEW_BIKE_COST * VelocityRatio)));
                        MoneyLost.Add(new MoneySubtraction("Hospital Bills", -(MAX_HOSPITAL_BILL * VelocityRatio)));
                    }
                }
            }
            else if (courtState == COURT_OUTCOME)
            {
                //unity blows
                if (!courtDecided)
                {
                    int num = Random.Range(0, decisionChance);
                    Debug.Log(num);
                    courtDecision = (num > 50);
                    courtDecided = true;
                }
                GUI.Box(new Rect(s_width / 2 - 150, s_height / 2 - 25, 300, 50), "\nYou have " + (courtDecision ? "won " : "lost ") + "the case");
                if (GUI.Button(new Rect(s_width / 2 - 50, s_height / 2 + 30, 100, 50), "OK"))
                {
                    if (!courtDecision)
                    {
                        MoneyLost.Add(new MoneySubtraction("Court Costs", -500));
                        MoneyLost.Add(new MoneySubtraction("Lawyer", -300));
                        MoneyLost.Add(new MoneySubtraction("Court Costs", -300));
                    }
                    else
                    {
                        MoneyLost.Add(new MoneySubtraction("Court Settlement", 2500));
                        MoneyLost.Add(new MoneySubtraction("Lawyer", -300));
                        MoneyLost.Add(new MoneySubtraction("Court Costs", -300));
                    }
                    courtState = FINAL_MONEY_SCENE;
                }
            }
            else if (courtState == FINAL_MONEY_SCENE)
            {
                int StartPosition = s_height / 2 - (int)(0.5 * (MoneyLost.Count * 25));
                float totalMoneyChange = 0;
                string text2display = "\n";
                foreach (MoneySubtraction m in MoneyLost)
                {
                    totalMoneyChange += m.amount;
                    text2display += m.Reason + "   " + m.amount.ToString() + "\n\n";
                }
                text2display += "\nTotal: " + totalMoneyChange;
                GUI.Box(new Rect(s_width / 2 - 250, StartPosition, 500, MoneyLost.Count * 40 + 30), text2display);
                if (GUI.Button(new Rect(s_width / 2 - 50, StartPosition + MoneyLost.Count * 40 + 30 + 10, 100, 50), "OK"))
                {
                    GoldAmount += Mathf.FloorToInt(totalMoneyChange);
                    courtState = RESTART_GAME;
                }
            }
            else if (courtState == RESTART_GAME)
            {
                //retart the game.
                Debug.Log("TRYING TO DIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                inCourt = false;
                BP.DieNotRetarded();
                GetNewStats();
            }
        }
    }
    //c# is quite literally the worst language ever made. if i spent my entire life writing in this managed crap i would die for sure.
    void Update()
    {
    }
    void GetNewStats()
    {
        BP = GameObject.Find("Player").GetComponent<BasePlayer>();
        decisionChance = 100;
        VelocityRatio = 0.0f;
        AudioListener[] myListeners = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
        foreach (AudioListener thisListener in myListeners)
        {
            thisListener.enabled = false;
        }
    }

    public void GoToCourt(float velocityOnCrash, bool crashedIntoCar = true)
    {
        GetNewStats();
        inCourt = true;
        courtState = INITIAL_QUESTION;
        iVel = velocityOnCrash;
        hitACar = crashedIntoCar;
        VelocityRatio = iVel / BP.movement.max_velocity;
        if (VelocityRatio <= 0)
            VelocityRatio = 0.001f;
        decisionChance += Mathf.FloorToInt(30*velocityOnCrash);
        ChanceOfWinning = ((float)((((float)decisionChance - 50f) / (float)decisionChance) * 100f)).ToString();
    }

    public static gamemonitor instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(instance);
            instance = this;
        }
    }
}