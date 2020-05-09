package chapter3;

import java.util.LinkedList;
import java.util.Random;

/**
 * Class which demonstrates how bin sort can be used to sort distinct integer
 * numbers between 0 and MAX_VALUE
 */
public class E36 {

    public static void main(String[] args) {
        Random rand = new Random();
        final int MAX_VALUE = 5;
        LinkedList<Integer> ll = new LinkedList();
//      for (int i=0;i<5;i++)
//      {
//          ll.add(rand.nextInt(10));
//      }
        ll.add(3);
        ll.add(2);
        ll.add(2);
        ll.add(4);
        ll.add(3);
        System.out.println(ll);
        boolean[] flags = new boolean[MAX_VALUE + 1]; //initially all false
        // determine which bins should be set to true
        LinkedList<Integer> ll2=new LinkedList();
        for (int i = 0; i < ll.size(); i++) {
            if(flags[ll.get(i)]==true)
            {
                ll2.add(ll.get(i));
            }
            flags[ll.get(i)] = true;
        }
        System.out.println(ll2);
        // use the flags to put the numbers back in the list sorted
        int flagNo = 0;
        for (int i = 0; i < ll.size(); i++) {  // find the next flag that is true
            while (flagNo < flags.length && !flags[flagNo]) {
                System.out.println(flags[flagNo]);
                System.out.println(flagNo);
                flagNo++;
                
            }
            ll.set(i, flagNo++);
        }
        // output the results
        for (int i = 0; i < ll.size(); i++) {
            System.out.print(((i > 0) ? ", " : "") + ll.get(i));
        }
        System.out.println();
    }
}