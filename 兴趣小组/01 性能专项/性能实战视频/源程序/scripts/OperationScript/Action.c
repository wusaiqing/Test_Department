#include "web_api.h"

Action()
{
	lr_start_transaction("µÇÂ¼");

	web_url("MercuryWebTours",
		"URL=http://localhost/MercuryWebTours/",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t2.inf",
		"Mode=HTML",
		LAST);

	web_submit_form("login.pl",
		"Snapshot=t3.inf",
		ITEMDATA,
		"Name=username", "Value={username}", ENDITEM,
		"Name=password", "Value=111111", ENDITEM,
		"Name=login.x", "Value=58", ENDITEM,
		"Name=login.y", "Value=14", ENDITEM,
		LAST);

	lr_end_transaction("µÇÂ¼", LR_AUTO);


	lr_rendezvous("Í¬Ê±¶©Æ±");

	lr_start_transaction("ÒµÎñ´¦Àí");

	web_url("welcome.pl",
		"URL=http://localhost/MercuryWebTours/welcome.pl?page=search",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=http://localhost/MercuryWebTours/nav.pl?page=menu&in=home",
		"Snapshot=t4.inf",
		"Mode=HTML",
		LAST);

	web_submit_form("reservations.pl",
		"Snapshot=t5.inf",
		ITEMDATA,
		"Name=depart", "Value=London", ENDITEM,
		"Name=departDate", "Value=04/11/2007", ENDITEM,
		"Name=arrive", "Value=Denver", ENDITEM,
		"Name=returnDate", "Value=04/12/2007", ENDITEM,
		"Name=numPassengers", "Value=1", ENDITEM,
		"Name=roundtrip", "Value=<OFF>", ENDITEM,
		"Name=seatPref", "Value=None", ENDITEM,
		"Name=seatType", "Value=Coach", ENDITEM,
		"Name=findFlights.x", "Value=84", ENDITEM,
		"Name=findFlights.y", "Value=15", ENDITEM,
		LAST);

	web_submit_form("reservations.pl_2",
		"Snapshot=t6.inf",
		ITEMDATA,
		"Name=outboundFlight", "Value=200;338;04/11/2007", ENDITEM,
		"Name=reserveFlights.x", "Value=74", ENDITEM,
		"Name=reserveFlights.y", "Value=10", ENDITEM,
		LAST);

   //´Ë²¿·ÖÄú¿ÉÒÔ½øÐÐ²ÎÊý»¯¹¤×÷£
	web_submit_form("reservations.pl_3",
		"Snapshot=t7.inf",
		ITEMDATA,
		"Name=firstName", "Value=John", ENDITEM,
		"Name=lastName", "Value=Tomas", ENDITEM,
		"Name=address1", "Value=Peking", ENDITEM,
		"Name=address2", "Value=100084", ENDITEM,
		"Name=pass1", "Value=John Tomas", ENDITEM,
		"Name=creditCard", "Value=", ENDITEM,
		"Name=expDate", "Value=", ENDITEM,
		"Name=saveCC", "Value=<OFF>", ENDITEM,
		"Name=buyFlights.x", "Value=57", ENDITEM,
		"Name=buyFlights.y", "Value=12", ENDITEM,
		LAST);

	lr_end_transaction("ÒµÎñ´¦Àí", LR_AUTO);



	lr_start_transaction("µÇ³ö");

	web_url("welcome.pl_2",
		"URL=http://localhost/MercuryWebTours/welcome.pl?signOff=1",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=http://localhost/MercuryWebTours/nav.pl?page=menu&in=flights",
		"Snapshot=t8.inf",
		"Mode=HTML",
		LAST);

	lr_end_transaction("µÇ³ö", LR_AUTO);

	return 0;
}
