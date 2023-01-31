namespace Maths;
public class MathEngine{
    //asset 
    public int Result{get;set;}
    public void Addition(int num1, int num2){
         this.Result= num1+ num2;
    }
    public void Subtraction(int num1, int num2){
        this.Result= num1-num2;
    }
}