#pragma once
#include "PluginSettings.h"
#include "SaveLoadIO.h"

#ifdef __cplusplus
extern "C"
{
#endif
	PLUGIN_API void saveScore(int score);
	PLUGIN_API int loadScore();

#ifdef __cplusplus
}
#endif