using System;
using static System.Console;
using System.Globalization;
class GreenvilleRevenue
{
    static void Main(string[] args)
    {
        AdultContestant[] adultContestants;
        TeenContestant[] teenContestants;
        ChildContestant[] childContestants;

        int noofContesttant = 0;
        bool valid = false;
        string input;
        char cInput;
        while (!valid)
        {
            try
            {
                Console.WriteLine("Enter Number of Contestants between 0 and 30 : ");
                noofContesttant = int.Parse(Console.ReadLine());
                if (noofContesttant >= 0 && noofContesttant <= 30)
                    valid = true;
                else
                {
                    valid = false;
                    Console.WriteLine("Number must be between 0 and 30");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Number must be between 0 and 30");
            }
        }


        adultContestants = new AdultContestant[noofContesttant];
        teenContestants = new TeenContestant[noofContesttant];
        childContestants = new ChildContestant[noofContesttant];

        int index = 0;
        int age;
        string Age;
        int childIndex = 0;
        int teenIndex = 0;
        int adultIndex = 0;
        string sScan;
        char scan;
        valid = false;
        while (index != noofContesttant)
        {
            Contestant c = new Contestant();
            ChildContestant x = new ChildContestant();
            TeenContestant y = new TeenContestant();
            AdultContestant z = new AdultContestant();
            Console.Write("\nEnter contestant({0}) name : ", (index + 1));
            c.Name = Console.ReadLine();
            x.Name = c.Name;
            y.Name = c.Name;
            z.Name = c.Name;
            Console.WriteLine("The Talent codes are:");
            for (int i = 0; i < Contestant.talentCodes.Length; i++)
            {
                char ch = Contestant.talentCodes[i];
                string s = Contestant.talentStrings[i];
                Console.WriteLine("{0} {1}", ch, s);
            }

            Console.Write("Enter {0} talent code : ", c.Name);
            sScan = ReadLine().ToUpper();
            scan = Convert.ToChar(sScan);
            while (!valid)
            {
                try
                {

                    if (scan == 'S' || scan == 'D' || scan == 'M' || scan == 'O')
                        valid = true;
                    else
                    {
                        valid = false;
                        Console.WriteLine("{0} is not a valid talent code. Assigned as Invalid.", scan);
                        Console.Write("Enter {0} talent code : ", c.Name);
                        scan = Convert.ToChar(Console.ReadLine());
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not a valid talent code. Assigned as Invalid.", scan);
                }
            }

            c.TalentCode = scan;
            x.TalentCode = c.TalentCode;
            y.TalentCode = c.TalentCode;
            z.TalentCode = c.TalentCode;
            Console.WriteLine("Enter {0} age : ", c.Name);
            Age = Console.ReadLine();
            age = Convert.ToInt32(Age);

            if (age <= 12)
            {

                childContestants[childIndex] = x;
                ++childIndex;

            }
            else if (age >= 13 && age <= 17)
            {
                teenContestants[teenIndex] = y;
                ++teenIndex;
            }
            else if (age >= 18)
            {
                adultContestants[adultIndex] = z;
                ++adultIndex;
            }
            index++;

        }
        double revenue = (childIndex * 15) + (teenIndex * 20) + (adultIndex * 30);
        Console.WriteLine("Revenue expected this year is: {0}", revenue.ToString("C", CultureInfo.GetCultureInfo("en-US")));

        Console.Write("Enter a talent type or 'Z' to quit >> ");
        input = Console.ReadLine().ToUpper();
        cInput = Convert.ToChar(input);
        valid = false;
        while (!valid)
        {
            try
            {

                if (cInput == 'S' || cInput == 'D' || cInput == 'M' || cInput == 'O')
                    valid = true;
                else
                {
                    valid = false;
                    Console.WriteLine("{0} is not a valid code", cInput);
                    Console.Write("Enter a talent type or 'Z' to quit >> ");
                    input = Console.ReadLine().ToUpper();
                    cInput = Convert.ToChar(input);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not a valid code", cInput);
            }
        }
        if (cInput == 'S')
            Console.WriteLine("Contestants with talent Singing are:");
        if (cInput == 'D')
            Console.WriteLine("Contestants with talent Dancing are:");
        if (cInput == 'M')
            Console.WriteLine("Contestants with talent Musical instrument are:");
        if (cInput == 'O')
            Console.WriteLine("Contestants with talent Other are:");


        while (input != "Z")
        {
            for (int i = 0; i < childIndex; i++)
            {
                char code = childContestants[i].TalentCode;
                if (code == cInput)
                {
                    Console.WriteLine(childContestants[i].ToString());

                }

            }
            for (int i = 0; i < teenIndex; i++)
            {
                char code = teenContestants[i].TalentCode;
                if (code == cInput)
                {
                    Console.WriteLine(teenContestants[i].ToString());

                }

            }
            for (int i = 0; i < adultIndex; i++)
            {
                char code = adultContestants[i].TalentCode;
                if (code == cInput)
                {
                    Console.WriteLine(adultContestants[i].ToString());

                }

            }
            Console.Write("\nEnter a skill code 'S', 'D', 'M', or 'O' to see a list of contestants with that skill or enter 'Z' to exit : ");
            input = Console.ReadLine().ToUpper();


        }
    }
}
public class Contestant
{
    public static char[] talentCodes = { 'S', 'D', 'M', 'O' };
    public static string[] talentStrings = { "Singing", "Dancing", "Musical instrument", "Other" };
    public static double fee;



    public double Fee
    {
        get { return fee; }
        set { fee = value; }
    }

    public string Name { set; get; }
    char code;
    public string Talent;

    public char TalentCode
    {
        get { return code; }
        set
        {
            string val = value.ToString().ToUpper();
            if (val == "S")
            {
                code = Convert.ToChar(val);
                Talent = talentStrings[0];
            }
            else if (val == "D")
            {
                code = Convert.ToChar(val);
                Talent = talentStrings[1];
            }
            else if (val == "M")
            {
                code = Convert.ToChar(val);
                Talent = talentStrings[2];
            }
            else if (val == "O")
            {
                code = Convert.ToChar(val);
                Talent = talentStrings[3];
            }
            else
            {
                code = 'I';
                Talent = "Invalid";
            }
        }
    }
    public string talentDescription { get { return Talent; } }
}

public class ChildContestant : Contestant
{
    public ChildContestant()
    {
        Fee = 15;
    }
    public override string ToString()
    {
        return "Child Contestant " + Name + " " + TalentCode + "   Fee " + Fee.ToString("C", CultureInfo.GetCultureInfo("en-US"));
    }
}
public class TeenContestant : Contestant
{
    public TeenContestant()
    {
        Fee = 20;
    }
    public override string ToString()
    {
        return "Teen Contestant " + Name + " " + TalentCode + "   Fee " + Fee.ToString("C", CultureInfo.GetCultureInfo("en-US"));
    }
}
public class AdultContestant : Contestant
{
    public AdultContestant()
    {
        Fee = 30;
    }
    public override string ToString()
    {
        return "Adult Contestant " + Name + " " + TalentCode + "   Fee " + Fee.ToString("C", CultureInfo.GetCultureInfo("en-US"));
    }
}

