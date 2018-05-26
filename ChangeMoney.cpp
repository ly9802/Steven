/*
 In Australia, there are $1,$2,$5,$10,$20,$50,$100 in terms of the amount of cash.
 assume that we only have $1,$2,$5, three kinds of cash. The quantity for each kind is enough.
 if we need to change $7 for some samll money. the ways are as follow:
 1:$7=$1+$1+$1+$1+$1+$1+$1
 2:$7=$1+$1+$1+$1+$1+$2
 3:$7=$1+$1+$1+$2+$2
 4:$7=$1+$2+$2+$2
 5:$7=$1+$1+$5
 6:$7=$2+$5
 There are 6 ways to chage $7
 Now, we need to change $100 for some small money. 
 This program is used to calculate how many ways to change $100.
*/
#include <iostream>
using namespace std;
void changeprocess(int currenttotal,int current,int small[],int &money,int &methods){
	if(currenttotal<money){
	   int i=0;
	  for(i=current;i<3;i++){
	    currenttotal=currenttotal+small[i];
	    if(currenttotal>money){currenttotal=currenttotal-small[i];break;}
	    else{
		 changeprocess(currenttotal,i,small,money,methods);
		 currenttotal=currenttotal-small[i];
		}
        
	 }//end for
    }//end if
	   if(currenttotal==money){ 
		    methods=methods+1;
		}
	

}//end changeprocessh
void main(){
 int money=100;// $100 is needed to be changed for a small money
 int ways[101];//the array ways is used to store how many ways to change a certain amount of cash(amoun=index)
 int smallmoney[3]={1,2,5}; //the array small money is used to store three kinds of the small money
 int i=0,amount=0;
 // use array to store the ways corresponding the money. for example, ways[9] represent how many ways to change $9 for a small money
 int sum=0;
 int number=0;
 for(i=0;i< money;i++){ways[i]=0;}//initialize the array ways;
 ways[0]=1; //initially, ways[0]=1 means there is an existed way.;
 ways[1]=1;//$1 just has 1 way,$1=$1
 ways[2]=2;//$2 has 2 ways, $2=$1+$1 or $2
 
 // calculate how many ways to change cash from $3 to $8
 
 for(amount=3;amount<9;amount++){
	 sum=0;
	 number=0;//number is used to store how many ways to change for the cash equals to amount
	 for(i=0;i<3;i++){
	   sum=sum+smallmoney[i];
	   changeprocess(sum,i,smallmoney,amount,number);
	   sum=sum-smallmoney[i];
	 }
	 ways[amount]=number;
 }
 //print how many ways to change cash from $1 to $8
 for(i=1;i<9;i++){
	 cout<<"if you want to change $"<<i<<",there are "<<ways[i]<<" ways"<<endl;
 }
 //calculate and print how many ways to change cash from &9 to &100
 for(amount=9;amount<101;amount++){
 ways[amount]=ways[amount-1]+ways[amount-2]+ways[amount-5]-ways[amount-3]-ways[amount-6]-ways[amount-7]+ways[amount-8];
 cout<<"if you want to change $"<<amount<<",there are "<<ways[amount]<<" ways"<<endl;
 }
 //cout<<"if you want to change $"<<amount-1<<",there are "<<ways[amount-1]<<" ways"<<endl;
 
}
