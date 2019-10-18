#include "SaveLoadIO.h"

void SaveLoadIO::saveScore(int score) {
	outFile.open("score.txt");

	outFile << to_string(score);

	outFile.close();
}

int SaveLoadIO::loadScore() {
	inFile.open("score.txt");
	string line;

	if (inFile.is_open()) {
		while (getline(inFile, line));
	}
	inFile.close();
	int x = stoi(line);
	return x;
	
}