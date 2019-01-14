
#include "lrs.h"


Action()
{
    lrs_create_socket("socket0", "TCP", "RemoteHost=yuy:3456",  LrsLastArg);
    lrs_send("socket0", "buf0", LrsLastArg);
    lrs_receive("socket0", "buf1", LrsLastArg);
    lr_think_time(197);
    lrs_send("socket0", "buf2", LrsLastArg);
    lrs_receive("socket0", "buf3", LrsLastArg);
    lr_think_time(48);
    lrs_send("socket0", "buf4", LrsLastArg);
    lrs_receive("socket0", "buf5", LrsLastArg);
    lr_think_time(40);
    lrs_send("socket0", "buf6", LrsLastArg);
    lrs_receive("socket0", "buf7", LrsLastArg);
    lrs_send("socket0", "buf8", LrsLastArg);
    lrs_receive("socket0", "buf9", LrsLastArg);
    lrs_send("socket0", "buf10", LrsLastArg);
    lrs_receive("socket0", "buf11", LrsLastArg);
    lrs_send("socket0", "buf12", LrsLastArg);
    lrs_receive("socket0", "buf13", LrsLastArg);
    lrs_send("socket0", "buf14", LrsLastArg);
    lrs_receive("socket0", "buf15", LrsLastArg);
    lrs_send("socket0", "buf16", LrsLastArg);
    lrs_receive("socket0", "buf17", LrsLastArg);
    lrs_send("socket0", "buf18", LrsLastArg);
    lrs_receive("socket0", "buf19", LrsLastArg);
    lrs_send("socket0", "buf20", LrsLastArg);
    lrs_receive("socket0", "buf21", LrsLastArg);
    lrs_send("socket0", "buf22", LrsLastArg);
    lrs_receive("socket0", "buf23", LrsLastArg);

    return 0;
}

