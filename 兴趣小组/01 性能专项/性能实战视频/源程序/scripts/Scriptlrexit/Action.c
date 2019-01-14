Action()
{


	//lr_exit(LR_EXIT_VUSER,LR_FAIL);
    //lr_exit(LR_EXIT_ACTION_AND_CONTINUE,LR_FAIL); 
	//lr_exit(LR_EXIT_MAIN_ITERATION_AND_CONTINUE,LR_FAIL); 
	//lr_exit(LR_EXIT_ITERATION_AND_CONTINUE,LR_FAIL); 
	lr_exit(LR_EXIT_VUSER_AFTER_ITERATION,LR_FAIL); 
	//lr_exit(LR_EXIT_VUSER_AFTER_ACTION,LR_FAIL); 

    lr_output_message("This is main Action()");
    
	return 0;
}
