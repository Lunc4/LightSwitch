class Programm
{
    class LightSwitch
    {
        // declare variables
        private int id;
        public List<LightBulb> bulbs;

        // constructor
        public LightSwitch(int id, List<LightBulb> bulbs)
        {
            this.id = id;
            this.bulbs = bulbs;
        }

        // add a lightbulb to the bulbs list
        public void AddLightBulb(LightBulb bulb)
        {
            bulbs.Add(bulb);
        }

        // nukes a bulb from the list
        // use id instead of bulb, faster or something
        public void DeleteLightBulb(int id)
        {
            bulbs.RemoveAt(id);
        }


        // looksup the id in the list. will be handled by the db later on
        // shouldn't even exist it's just to achieve crud without db
        public void GetState(int id)
        {
            foreach (LightBulb bulb in bulbs)
            {
                if (bulb.id == id)
                {
                    Console.WriteLine($"Builb {id} is {(bulb.state ? "on" : "off")}");
                }

            }
        }

        // toggles all the bulbs connected to the switch
        public void Toggle()
        {
            foreach (LightBulb bulb in bulbs)
            {
                bulb.ToggleState();
            }
        }

    }
    public class LightBulb
    {

        public int id;
        public bool state;
        // constructor
        public LightBulb(int id)
        {
            this.id = id;
            this.state = false;
        }


        // changes the state to (not state)
        public void ToggleState()
        {
            state = !state;
        }

    }
    static void Main(string[] args)
    {
        // temp obv; should and will be handled by mmsql
        int bulb_id = 0;
        int switch_id = 0;

        List<LightBulb> bulbs = new();


        LightBulb lightBulb = new(bulb_id);

        for (int i = 0; i < 10; i++)
        {
            bulbs.Add(new LightBulb(i));
        }

        LightSwitch lightSwitch = new(switch_id, bulbs);
        lightSwitch.GetState(7);


        lightSwitch.Toggle();
        lightSwitch.GetState(7);
    }
}