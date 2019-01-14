/*
 * LoadRunner Java script. (Build: 670)
 * 
 * Script Description: 
 *                     
 */

import lrapi.lr;

public class Actions
{
    int[] numArray = {1,3,5,43,54,67,9,20,15,23,66,60,5,12,2,63,22,6,54,42
                      ,70,90,40,20,50,89,89,53,21,56,7,32,51,74,88,99,100};
    //√∞≈›≈≈–Ú
	private void BubbleSort(int[] data) 
    {
	 for(int i=0; i <data.length; i++)
	   {
         for(int j = data.length-1; j > i; j--)
         {
             if(data[j] < data[j-1])
             {
                 swap(data,j,j-1);
             }
         }
       System.out.println(data[i] + "\t");
      }
	}


    //ªªŒª÷√∫Ø ˝
    private void swap(int[] data, int i, int j) {
        int temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }

    //≤Â»Î≈≈–Ú∫Ø ˝
    private void insertSort(int[] data, int start, int inc) {
        int temp;
        for(int i=start+inc;i<data.length;i+=inc){
            for(int j=i;(j>=inc)&&(data[j]<data[j-inc]);j-=inc){
                swap(data,j,j-inc);
            }
        }
    }

    //œ£∂˚≈≈–Ú
	private void ShellSort(int[] data) {

         for(int i=data.length/2;i>2;i/=2){
            for(int j=0;j<i;j++){
                insertSort(data,j,i);
            }
        insertSort(data,0,1);
    }

    for (int i=0 ;i<data.length;i++)
      System.out.println(data[i] + "\t");

}

	public int init() {
		return 0;
	}//end of init


	public int action() {
        lr.start_transaction("√∞≈›≈≈–Ú");
        	BubbleSort(numArray);
        lr.end_transaction("√∞≈›≈≈–Ú",lr.PASS);
        System.out.println("-----------------");
        lr.start_transaction("œ£∂˚≈≈–Ú");
			ShellSort(numArray);
        lr.end_transaction("œ£∂˚≈≈–Ú",lr.PASS);
		return 0;
	}//end of action


	public int end() {
		return 0;
	}//end of end
}
