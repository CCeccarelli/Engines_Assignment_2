#pragma once

#ifdef SaveLoadIO_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif SaveLoadIO_IMPORTS
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif