namespace Utility;
using Maths;
public static  class Helper{

    public static  void Multiplication(this MathEngine m,int num1, int num2){
        m.Result= num1* num2;
    }

    public  static  void Division(this MathEngine m,int num1, int num2){
        m.Result= num1/ num2;
    }

}