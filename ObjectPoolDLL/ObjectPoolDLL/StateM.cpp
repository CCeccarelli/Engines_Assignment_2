#include "StateM.h"

StateM::StateM() : M_state(new redState()) {

}

StateM::~StateM() {
	delete M_state
}

void StateM::RedState() {
	M_state->RedState(this);
}

void StateM::BlueState() {
	M_state->BlueState(this);
}

void StateM::setState(State state)
{
	delete M_state;

	if (state == RED)
	{
		M_state = new RedBlockState();
	}
	else if (state == BLUE)
	{
		M_state = new BlueBlockState();
	}

}