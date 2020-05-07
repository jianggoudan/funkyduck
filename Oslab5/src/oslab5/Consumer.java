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
public class Consumer implements Runnable {

    private Buffer buffer;

    Random rand = new Random();
    private  boolean running = true;

    public Consumer(Buffer buffer) {

        this.buffer = buffer;
    }

    public void terminate() {
        running = false;
    }

    @Override
    public void run() {
        while (running) {
            synchronized (buffer.items) {
                try {
                    //sleep a random time
                    Thread.sleep(rand.nextInt(1000));
                    //generate a random item
                    Buffer_item item = buffer.items.peek();
                   
                    if (buffer.remove_item() == -1) {

                        System.out.println("no item here " + Thread.currentThread().getId());
                        //stop this thread if buffer is empty
                        buffer.items.wait();
                    } else {
                        //wake up all other threads until it is full.
                        System.out.println("consumer id: " + Thread.currentThread().getId() + " consumer item: " +item.name+ "the buffer now contains " + buffer.items.size() + "items ");
                        buffer.items.notifyAll();

                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
