#pragma once

#ifdef StateMachine_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif StateMachine_IMPORTS
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif