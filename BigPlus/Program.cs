
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BigPlus;

public class Program
{
    public  static void Main(string[]args)
    {
        Program pr = new Program();
        Console.WriteLine("Hello World");
        Console.WriteLine(MyBenchmark.PlusBigNums());//("23532543262435234324325465686707897", "324325436540924729479282");
        //BenchmarkRunner.Run<MyBenchmark>();
        Console.ReadKey();
    }
}
public class MyBenchmark
{
   // [Benchmark]
    public static string PlusBigNums()
    { 
        string num1 = "47063278432742374687236263726846236428176327864286483270";
        string num2 = "470324387429837423472972389742740237402934709234720374320";
        int number1_InInt = 0, number2_InInt;
        int indexI = 0, isStrLongerThen = (num1.Length > num2.Length) ? num1.Length : num2.Length;
        int[] n1 = new int[isStrLongerThen+1], n2=new int[isStrLongerThen+1];
        char[] num1InArray = num1.ToCharArray();
        char[] num2InArray = num2.ToCharArray();
        Array.Reverse(num1InArray);
        Array.Reverse(num2InArray);
        
        foreach (var num in num1InArray)
        {
            number1_InInt = num - '0';
            n1[indexI]=number1_InInt;
            indexI++;
        } indexI = 0;
        foreach (var num in num2InArray)
        {
            number2_InInt = num - '0';
            n2[indexI]=number2_InInt;
            indexI++;
        } indexI = 0;
        char[] counterbuf = new char[2];
        char[] num3 = new char[isStrLongerThen+1];
        int cnt = 0;
        
        STARTPOINT:
        number1_InInt =(n1[indexI]+n2[indexI]);
        counterbuf=number1_InInt.ToString().ToCharArray();
        if (counterbuf.Length >= 2)
        {
            if (isStrLongerThen==indexI)
            {
                /*Array.Reverse(counterbuf);
                foreach (int value in counterbuf)
                {
                    num3[indexI]=Convert.ToChar(value);
                    cnt += value;
                }
                Array.Reverse(num3);
                if(num3[0]=='0')*/
                   // return new string(num3).Substring(1);

                return new string(num3);

            }

            foreach (int value in counterbuf)
            {
                num3[indexI]=Convert.ToChar(value);
            }
            counterbuf[1]='\0';
            cnt = counterbuf[0] - '0';
            n1[indexI + 1] += cnt;
            indexI++;
        }
        else
        {
            if (isStrLongerThen == indexI)
            {
                /*Array.Reverse(counterbuf);
                foreach (int value in counterbuf)
                {
                    num3[indexI]=Convert.ToChar(value);
                    cnt += value;
                }*/
                Array.Reverse(num3);
                /*if(num3[0]=='0')
                    return new string(num3).Substring(1);*/

                return new string(num3);
            }
            
            foreach (int value in counterbuf)
            {
                num3[indexI]=Convert.ToChar(value);
                cnt += value;
            }
            indexI++;
        }
        goto STARTPOINT;
    }
}