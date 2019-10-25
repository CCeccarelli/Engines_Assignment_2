#pragma once
#include "PluginSettings.h"

class PLUGIN_API StateM {
public:
	enum State
	{
		RED,
		BLUE
	};

	StateM();
	virtual ~StateM();

	void RedState();
	void BlueState();

	void setState(State state);


private:
	BlockState * M_state;

};