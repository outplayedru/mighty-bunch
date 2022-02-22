package field

import (
	"fmt"
	"strings"
	"sync"
)

type safeField struct {
	data []string
	sync.RWMutex
}

func (sf *safeField) Find(s string) int {
	// Lock only for read
	sf.RLock()
	defer sf.RUnlock()

	for i := range sf.data {
		if sf.data[i] == s {
			return i
		}
	}

	return -1
}

func (sf *safeField) Add(s string) {
	if sf.Find(s) != -1 {
		fmt.Printf("%s already at the field\n", s)
		return
	}

	// Full lock for read and write
	sf.Lock()
	defer sf.Unlock()

	sf.data = append(sf.data, s)
}

func (sf *safeField) String() string {
	return strings.Join(sf.data, ", ")
}
