// TestCppGit.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <atomic>
#include <thread>
#include <iostream>

using namespace std;

atomic<int> atomInt;
//int atomInt;

void ThreadOne()
{
	for (int i = 0; i < 10000000; ++i)
	{
		//atomInt++;
		atomInt++;
	}
}

void ThreadTwo()
{
	for (int i = 0; i < 10000000; ++i)
	{
		//atomInt--;
		atomInt--;
	}
}

int main()
{
	thread t1(ThreadOne);
	thread t2(ThreadTwo);

	atomic_flag flag = ATOMIC_FLAG_INIT;

	t1.join();
	t2.join();
	
	flag.test_and_set(memory_order)

	cout << atomInt << endl;

    return 0;
}

