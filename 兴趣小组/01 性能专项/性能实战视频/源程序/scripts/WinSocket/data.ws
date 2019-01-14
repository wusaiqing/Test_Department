;WSRData 2 1

send  buf0 55
	"4##SELECT agent_name FROM AGENTS ORDER BY agent_name###"

recv  buf1 55
	"0##Alex#Amanda#Debby#Julia#Mary#Robert#Sharon#Suzan###"
	"\x00"

send  buf2 68
	"2##1## SELECT DISTINCT departure FROM Flights ORDER BY departure ###"

recv  buf3 56
	"0##Denver#Los Angeles#Portland#San Francisco#Seattle###"
	"\x00"

send  buf4 300
	"2##0##SELECT departure, flight_number, departure_initials, day_of_week, ar"
	"rival_initials, arrival, departure_time, arrival_time, airlines, seats_ava"
	"ilable, ticket_price, mileage   FROM  Flights WHERE arrival = 'Portland' A"
	"ND departure = 'Denver' AND day_of_week = 'Thursday'ORDER BY flight_number"
	" ###"

recv  buf5 69
	"0##3012;250;2812;07:59 AM;DEN;Thursday;POR;09:40 AM;DA;148;Denver###"
	"\x00"

send  buf6 82
	"11##UPDATE Counters SET counter_value=counter_value+1 WHERE table_name='OR"
	"DERS'###"

recv  buf7 8
	"0##1###"
	"\x00"

send  buf8 67
	"12##SELECT counter_value FROM Counters WHERE table_name='ORDERS'###"

recv  buf9 10
	"0##106###"
	"\x00"

send  buf10 67
	"12##SELECT customer_no FROM Customers WHERE customer_name='tony'###"

recv  buf11 9
	"0##31###"
	"\x00"

send  buf12 59
	"12##SELECT agent_no FROM Agents WHERE agent_name='Debby'###"

recv  buf13 8
	"0##5###"
	"\x00"

send  buf14 195
	"11##INSERT INTO Orders (order_number,agent_no,customer_no,flight_number,de"
	"parture_date,tickets_ordered,class,send_signature_with_order) VALUES (106,"
	" 5, 31, 3012, {d '2009-01-01'}, 1, '3', 'N')###"

recv  buf15 8
	"0##1###"
	"\x00"

send  buf16 13
	"11##COMMIT###"

recv  buf17 8
	"0##0###"
	"\x00"


-1
