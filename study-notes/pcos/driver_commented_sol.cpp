/*
Example solution code for implementation of driver for a disk controller.
Disk controlled by 5 memory mapped registers

Block size: 512 B (not relevant)
Data transfer: through DMA
Operation finished: signalled through BUSY register
Machine type: 32-bit
Max disk size: 2 TB (not relevant)
*/

/// START: CODE ADDED TO AVOID ERRORS

#include <cstdint>
#include <cstdlib>

/// @brief Represents an object for mutual exclusion (a lock)
typedef struct {} mutex_t;

static void mutex_init(mutex_t *mutex){}
static void mutex_lock(mutex_t *mutex){}
static void mutex_unlock(mutex_t *mutex){}

/// END: CODE ADDED TO AVOID ERRORS

typedef volatile struct { // volatile: forces compiler to not cache the data (we want to read exactly what is in the register)
    uint32_t status;
    uint32_t size;
    uint32_t command;
    uint32_t lba;
    uint32_t dma;
} disk_regs_t;

typedef struct {
    size_t max_lba;
    disk_regs_t *ctl; // note that this is an address!
    mutex_t mutex;
} disk_t;

/// @brief Check the ERR flag of the register (using 0b0...01 as mask)
static bool disk_is_ok(disk_t *disk) 
{ 
    return (disk->ctl->status & 1) == 0; 
}

/// @brief Check the BUSY flag of the register (using 0b0...10 as mask)
static bool disk_is_ready(disk_t *disk) 
{ 
    return (disk->ctl->status & 2) == 0; 
}

/// @brief Perform active polling of the BUSY flag of the register. Return false if ERR flag triggered.
static bool disk_wait_for_ready(disk_t *disk) 
{
    while (!disk_is_ready(disk)) {
        if (!disk_is_ok(disk)) {
            return false;
        }
    }
    return true;
}

/// @brief Initializes the disk by setting the ctl pointer to the register_address 
bool disk_init(disk_t *disk, uint32_t register_address) 
{
    disk->ctl = (disk_regs_t *) register_address; // we store address of the register to ctl (since ctl is indeed an address!)
    disk->max_lba = disk->ctl->size; // retrieve the size from the currenlty loaded ctl and store to max_lba
    mutex_init(&disk->mutex);
    return disk_wait_for_ready(disk);
}

/// @brief Reads a single block from the disk
bool disk_read_block_waiting(disk_t *disk, size_t lba, uint32_t data_phys_addr) 
{
    // check if not asking for address that is out of range
    if (lba >= disk->max_lba) 
    {
        return false;
    }

    // lock the critical section
    mutex_lock(&disk->mutex);
    bool ok = disk_wait_for_ready(disk); // busy wait until disk ready or has error
    if (!ok) 
    {
        mutex_unlock(&disk->mutex); // if had error just unlock mutex and exit
        return false;
    }

    // write necessary data to the registers
    disk->ctl->lba = lba; 
    disk->ctl->dma = data_phys_addr; // set up address where to store the read data in RAM
    disk->ctl->command = 1; // issue read command

    // wait until operation finished and then release the lock
    ok = disk_wait_for_ready(disk); 
    mutex_unlock(&disk->mutex);

    return ok;
}