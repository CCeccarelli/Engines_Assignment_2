#pragma once

#include "PluginSettings.h"
#include <string>
#include<fstream>

using namespace std;
class PLUGIN_API SaveLoadIO {
public:

	void saveScore(int score);
	int loadScore();

private:

	ifstream inFile;
	ofstream outFile;
};