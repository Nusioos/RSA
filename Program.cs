using System;
public class RSA 
{ //zmienne
public int n;
public int gcd;
public int lambda;
public int e;
public int d;
public long code;
public long decode;
public int messege;
public RSA(){}
public int pick_d(int my_e,int my_lcm)// d finder
{
    int moje_d=1;
while(true)
{
    if((moje_d*my_e)%my_lcm==1)
    {
        break;
    }
    moje_d++;
}
return moje_d;
}
 public int pick_e(int lcm)// e finder
{
    int checker;
     int final;
   
while(true)
{
     Random rnd = new Random();
         checker= rnd.Next(1, lcm);
final=findGCD(checker,lcm);
if(final==1 && lcm>checker && checker>1)
{
    break;
}
}
return checker;
}
public long RSA_coding(int baseValue,int exponent,int modulo )//RSA kodowanie i dekodowanie
{
    long result=1;
    while(exponent>0)
    {
        if(exponent%2==1)
        {
            result = (result * baseValue) % modulo;
        }
        baseValue = (baseValue * baseValue) % modulo;
        exponent /= 2;
    }
return result;
}
public bool isprime(int i,int finish)//sprawdz czy prime
{
    int checker=0;
for(int start=1;start<finish;start++)
{
    if((i%start)==0)
    {
      checker++;
    }
    if(checker>2)
    {
     return false;
    }
}
return true;
}
public int findlcm(int a, int b) {// LCM finder
    return (a*b)/gcd;
}
public int findGCD(int a, int b) { //GCD finder
    if (a == 0)
        return b;
    return findGCD(b % a, a);
}
public int liczba_pierwsza() // Znajduje Radnom prime numbers
{
     int prime;
     Random rnd = new Random();
    while (true)
    {
        prime= rnd.Next(10, 100);
        bool czyprime=isprime(prime,100);
          if(czyprime==true)
          {
            break;
          }
    }
    return prime;
}
public  (int message, int d, int n,string test) w (ref (int messege,int d,int n,string test)RSA_tuple)
{
RSA postac = new RSA();
    int prime1=postac.liczba_pierwsza();
    int prime2=postac.liczba_pierwsza();
postac.find_n(prime1,prime2); 
RSA_tuple.n=  postac.n;
postac.gcd=postac.findGCD(prime1-1,prime2-1);
postac.lambda=postac.findlcm(prime1-1,prime2-1);
postac.e=postac.pick_e(postac.lambda);
postac.d=postac.pick_d(postac.e,postac.lambda);
RSA_tuple.d=postac.pick_d(postac.e,postac.lambda);
postac.code=postac.RSA_coding(RSA_tuple.messege,postac.e,postac.n);
    char[] znaki = RSA_tuple.test.ToCharArray();
RSA_tuple.messege=(int)postac.code;
for (int i=0;i<znaki.Length;i++)
  {
  int kod_ascii = (int)RSA_tuple.test[i];
  int kod_z=(int)postac.RSA_coding(kod_ascii,postac.e,postac.n);
     znaki[i] = (char)kod_z;
 //    Console.WriteLine($"litera:{znaki[i]}");
  }
  RSA_tuple.test = new string(znaki);
Console.WriteLine($"A to nasze prime1-1:{prime1-1}");
Console.WriteLine($"A to nasze prime2-1:{prime2-1}");
Console.WriteLine($"A to nasze gcd:{postac.gcd}");
Console.WriteLine($"A to nasze lambda:{postac.lambda}");
Console.WriteLine($"A to nasze n:{postac.n}");
Console.WriteLine($"A to nasze e:{postac.e}");
Console.WriteLine($"A to nasze d:{postac.d}");
Console.WriteLine($"nasz code:{postac.code}");
return (RSA_tuple.messege, RSA_tuple.d, RSA_tuple.n,RSA_tuple.test);
}
public int find_n(int prime1,int prime2)// N finder
    {
int klucz_n=prime1*prime2;
n=klucz_n;
Console.WriteLine($"prime1:{prime1} prime2:{prime2}");
return n;
    }
}
public class Program // MAIN
{
    static void Main(string[] args)
    {
string test="bastian_cwel";
Console.WriteLine($"original:{test}");
RSA postac = new RSA();
int messege=(int)test[0];
int d=0;
int n=0;
(int messege,int d,int n,string test) dane=(messege,d,n,test);
 postac.w(ref dane);
Console.WriteLine($"d:{dane.d} , n:{dane.n},code:{dane.test}");
int code=(int)postac.RSA_coding(dane.messege,dane.d,dane.n);
char[] decode_test = dane.test.ToCharArray();
for(int i=0;i<test.Length;i++)
{
    int zasz=dane.test[i];
    int kod_z=(int)postac.RSA_coding(zasz,dane.d,dane.n);
    decode_test[i] = (char)kod_z;
    //Console.WriteLine($"litera:{decode_test[i]}");
}
string decode_final = new string(decode_test);
Console.WriteLine($"decode: {decode_final}");
    }
}

