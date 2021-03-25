using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    //================================= Project Documentation =================================
    // Project Name : Understanding Multicharts Under the Hood
    // Platform     : Console Application
    // Class Type   : 
    // Version      : v.1.0.0
    // Date         : 03 Feb 2021
    // Developer    : Sher Ning
    //=========================================================================================
    // Copyright    : 2020, Sher Ning Technologies           
    // License      : Internal use
    // Client       : Sher Ning
    // Contact      : sherning@hotmail.com
    //=========================================================================================
    // References   :       
    // Obectives    : 
    // Returns      : 
    // Remarks      : 
    //=========================================================================================

    static class UnderstandingMC
    {
        public static void Run()
        {
           
        }
    }

    public sealed class StrategyTest : FunctionSeries<int>
    {
        public StrategyTest(CStudyControl m) : base(m)
        {

        }
        protected override void StartCalc()
        {
        }
        protected override int CalcBar()
        {
            Console.WriteLine("Strategy Test: " + Master.ExecInfo.MaxBarsBack);
            return 0;
        }
    }

    public abstract class FunctionSeries<T> : FunctionObject<T>
    {
        public FunctionSeries(CStudyControl m) : base(m)
        {

        }
    }

    public abstract class FunctionObject<T> : CStudyControl
    {
        protected CStudyControl Master;
        public FunctionObject(CStudyControl master)
        {
            Master = master;
        }

        protected abstract T CalcBar();
        protected virtual void StartCalc()
        {

        }
        protected virtual void Create()
        {
        }
    }

    public class CStudyControl
    {
        public ICalculationInfo ExecInfo { get; }
    }

    public interface ICalculationInfo
    {
        int MaxBarsBack { get; set; }
    }

    public class CalculationInfo : ICalculationInfo
    {
        public int MaxBarsBack { get; set; }
    }

}
