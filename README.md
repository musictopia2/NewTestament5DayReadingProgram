# NewTestament5DayReadingProgram
This is a web assembly app where it allows people to participate in a program to read through the entire new testament in one year by reading Monday through Friday

Installation Instructions:
Temporary instructions is to just run the project in visual studio.
I will later create an azure static site.  The repository for azure static has to be private otherwise, if a person forks it and makes changes, then it would publish to my azure static site which is not good.

Known Issues:
Anybody on IPhone or IPad, if they don't go into this for 7 days, then any local storage stuff will be deleted.  This means if they go 7 days without doing the reading, then when going back in, will reload from the current day so those days would permanantly be skipped.  There is nothing I can do about it unfortunately because of the restrictions that apple places.

Roadmap:

These are the things I want to accomplish:
 * Allow a way for users to keep track of their readings for the year
 * Allow a user to change their translation used
 * Once a reading has been completed for the day, will display a friendly message saying they already completed the reading.
 * Install as a PWA (progressive web app) so it works completely offline.


Here are my version plans:

#Version 1 (done)
 * will use a mock date and will just show the book and chapter that will be read. (Done)
 This will be the starting point to prove that its able to capture book and chapter for the day.
 If its Saturday or Sunday, will display a different message
 
 #Version 2 (done)
 * will actually show the reading but still for a mock date using the new king james version of the bible (Done)

 #Version 3 (done)
 * will allow somebody to change translation (done)
 * will save in local storage (at this point, for ios users, if they don't use this in 7 days, they will lose what translation chosen) (done)
 * still use mock dates (done)
 * allow to enter new dates to prove it will work into the future (done)

 #Version 4 (done)
 * will finally use real date
 * by this time, it is proven to work for all dates (even years into the future)

 #Version 5 (done)
 * will keep track of progress for the readings in local storage.
 
 the last stage is testing.   I will go ahead and wait some days to show I can catch up.  The final test would have to be at the end of the year.
 
