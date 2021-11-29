ClassWithMethods classWithMethods = new ClassWithMethods();

//Callback mithilfe eines Delegates
MessageDelegate messageDel = new  MessageDelegate(classWithMethods.FinishMessage);
classWithMethods.StartWorkflow(11,22, messageDel);

//Callback mithilfe eines Delegates(Action) 
Action<string> actionMessageDelegate = new Action<string>(classWithMethods.FinishMessage);
classWithMethods.StartWorkflow(11, 33, actionMessageDelegate);







public delegate void MessageDelegate(string message);

public class ClassWithMethods
{
    public void StartWorkflow(int param1, int param2, Action<string> messageDelegate)
    {
        //Call SQLServer 
        //Asynchronität 
        //Threadings

        //Hier muss uns expliziet gesagt werden, wir sind fertig
        //Hier müssen wir mithilfe eines Delegates signalisieren, dass wir mit StartWorkflow fertig sind. 
        messageDelegate("bin fertig");
    }
    public void StartWorkflow(int param1, int param2, MessageDelegate messageDelegate) //dieses Delegate verwendet immer noch die FinishMessage-Methode
    {
        //Call SQLServer 
        //Asynchronität 
        //Threadings



        //Hier muss uns expliziet gesagt werden, wir sind fertig
        //Hier müssen wir mithilfe eines Delegates signalisieren, dass wir mit StartWorkflow fertig sind. 

        messageDelegate("Ich bin fertig");
    }
    public void FinishMessage(string message)
    {
        Console.WriteLine(message);
    }
}