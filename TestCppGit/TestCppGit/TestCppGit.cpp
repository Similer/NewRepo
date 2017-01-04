// TestCppGit.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <atomic>
#include <thread>
#include <iostream>

using namespace std;

atomic<int> atomInt;

void ThreadOne()
{
	atomInt.fetch_add(1, memory_order_release);
}

void ThreadTwo()
{
	atomInt.load(memory_order_acquire);
}

int main()
{
	thread t1(ThreadTwo);
	thread t2(ThreadOne);

	t1.join();
	t2.join();
	

	atomic_flag flag = ATOMIC_FLAG_INIT;
	flag.test_and_set();
    return 0;
}

