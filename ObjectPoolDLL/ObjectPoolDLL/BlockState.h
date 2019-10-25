#pragma once
#include <string>;

class BlockState
{
public:
	BlockState(std::string name);
	virtual ~BlockState();

	virtual void RedState(StateM * StateMachine);
	virtual void BlueState(StateM * StateMachine);

	
private:
	std::string M_Name;
};

