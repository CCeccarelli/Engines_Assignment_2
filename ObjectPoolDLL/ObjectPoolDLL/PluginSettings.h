#pragma once

#ifdef ObjectPoolDLL_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif ObjectPoolDLL_IMPORTS
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif