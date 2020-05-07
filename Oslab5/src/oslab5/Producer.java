/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package oslab5;

import java.util.Random;

/**
 *
 * @author jiang
 */
public class Producer implements Runnable {

    private Buffer buffer;
    private boolean running = true;
    Random rand = new Random();

  
    public void terminate() {
        running = false;
    }

    public Producer(Buffer buffer) {
        
        this.buffer = buffer;
    }

    @Override
    public void run() {
        while (running) {
            synchronized (buffer.items) {
                try {
                    //sleep a random time
                    Thread.sleep(rand.nextInt(1000));
                     Buffer_item  item = new Buffer_item(rand.nextInt(1000));
                    
                    if (buffer.insert_item(item) == -1) {
                        //stop this thread if buffer if full
                        System.out.println("buffer is full "+Thread.currentThread().getId());
                        buffer.items.wait();
                    } else {
                        //wake up all other thread until it is full
                        System.out.println("producer ID:"+Thread.currentThread().getId()+"  produced item: "+item.name+"the buffer now contains "+buffer.items.size()+"items ");
                        buffer.items.notifyAll();
                        
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
