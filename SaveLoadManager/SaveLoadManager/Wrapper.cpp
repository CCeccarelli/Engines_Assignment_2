#include "Wrapper.h"

SaveLoadIO io;

void saveScore(int score) {
	return io.saveScore(score);
}

int loadScore() {
	return io.loadScore();
}