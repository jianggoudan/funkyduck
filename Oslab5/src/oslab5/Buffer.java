/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package oslab5;

import java.util.LinkedList;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author jiang
 */
public class Buffer {

    public static int BUFFER_SIZE = 1;
    public LinkedList<Buffer_item> items = new LinkedList<>();

    //insert function that return 0 if insert sucessfully or -1 if not insert
    //sucessfully
    public int insert_item(Buffer_item item) {

        if (items.size() + 1 > BUFFER_SIZE) {

            return -1;
        } else {
            items.offer(item);

            return 0;
        }
    }
//remove function that return 0 if remove sucessfully or -1 if not remove
    //sucessfully

    public int remove_item() {

        if (items.size() == 0) {

            return -1;
        } else {
            items.poll();

            return 0;
        }

    }

    public static void main(String[] args) {
        try {
            //creat threads
            Buffer storage = new Buffer();
            Producer producer = new Producer(storage);
            Consumer consumer = new Consumer(storage);
            Thread p1 = new Thread(producer);
            Thread p2 = new Thread(producer);
            Thread p3 = new Thread(producer);
            Thread p4 = new Thread(producer);
            Thread p5 = new Thread(producer);

            Thread c1 = new Thread(consumer);
            Thread c2 = new Thread(consumer);
            Thread c3 = new Thread(consumer);
            Thread c4 = new Thread(consumer);
            Thread c5 = new Thread(consumer);

            p1.start();
             p2.start();
              p3.start();
               p4.start();
                p5.start();
            c1.start();
             c2.start();
              c3.start();
               c4.start();
                c5.start();
                

            //sleep 10s.
            Thread.sleep(10000);
            //terminate application
            consumer.terminate();
            producer.terminate();

        } catch (InterruptedException ex) {
            Logger.getLogger(Buffer.class.getName()).log(Level.SEVERE, null, ex);
        }

    }
}
