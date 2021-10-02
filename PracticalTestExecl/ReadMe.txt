Normaize DB

student(id, first_name, last_name, dob, gender, email, ethnicity_id, status_id, acadamic_id, exclusion_id?, act_id?, sat_id?, hs_id)
acadamic(id, academic_period, entry_age, ged, english_secnd_lag, first_gen)
exclusion(id, exclusion_type)
act(id, composite, math, english, reading)
sat(id, combined, math, verbal, reading)
hs(id, city, state, zip)
ethnicity(id, name)

other than above===================================
state(id, state)
address(id, city, state_id)
hs(id, zip, address_id)