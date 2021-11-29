using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandlerInNET5
{
    public delegate void Percent(int n);
    public delegate void SizeChange(int newSize);
    public delegate void Notify();

    public class ProcessBusinessLogic
    {

        public event Notify ProcessCompleted; // Methoden werden von draußen drangehängt (Funktionzeiger) 
        public event Percent CurrentPercentStatus;

        public void StartProcess()
        {
            for (int i = 0; i < 100; i++)
            {
                //Prozentanzeige nach draussen bauen
                OnProcessPercentStatus(i);
            }



            //Finish-Meldung -> Callback nach draußen 
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }

        protected virtual void OnProcessPercentStatus(int percent)
        {
            CurrentPercentStatus?.Invoke(percent); //Invoke auf Programm.ProcessBusinessLogic_CurrentPercentStatus(int n)
        }
    }
}
