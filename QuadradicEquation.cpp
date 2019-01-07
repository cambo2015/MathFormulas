
#include <iostream>
#include <tgmath.h>
using namespace std;


template<typename T>
class QuadradicEquation
{
    T num;
    float &A;
    float &B;
    float &C;
    
    public:
        QuadradicEquation(float a, float b,float c)
        :A(a),B(b),C(c)
        {
        }
        
        T plus()
        {
            return (-B+(float)sqrt(B*B-4*A*C)) /(2*A);
        }
        T minus()
        {
            return (-B-(float)sqrt(B*B-4*A*C)) /(2*A);
        }
    
};

template<typename T>
extern void p(T item)
{
    cout<<item<<endl;
}
int main()
{
    //print(-1-sqrt(3));//this is the answer
    
    float a =2,b= 4,c=-4;
    auto *quad = new QuadradicEquation<float>(a,b,c);
    p(quad->plus());
    p(quad->minus());
  delete quad;
    return 0;
}