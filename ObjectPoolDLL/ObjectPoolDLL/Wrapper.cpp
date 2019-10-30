#include "Wrapper.h"

ObjectPool op;

std::string stringReturn(std::string name) {

	return op.testString(name);
}
