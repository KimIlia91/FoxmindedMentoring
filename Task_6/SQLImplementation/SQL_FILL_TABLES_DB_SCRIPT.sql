USE [HogwartsDB]
GO

INSERT INTO COURSES (NAME, DESCRIPTION) VALUES ('Transfiguration', 'Transfiguration is the family of magical spells that are used for changing  objects from one type of thing into another. At Hogwarts, Transfiguration is taught by Professor Minerva  McGonagall.')
INSERT INTO COURSES (NAME, DESCRIPTION) VALUES ('Potions', 'In this course, STUDENTS learn how to properly brew potions. They follow certain recipes and use various magical ingredients to create potions, starting from simple ones and moving on to more  complex ones as they progress in knowledge. Potions is taught by Professor Severus Snape.')
INSERT INTO COURSES (NAME, DESCRIPTION) VALUES ('Herbology', 'Herbology is the study of magical and mundane plants and fungi. In Herbology, STUDENTS learn to care for and utilize plants, and learn about their magical properties, and what they are used for. Herbology is taught by Professor Pomona Sprout.')
INSERT INTO COURSES (NAME, DESCRIPTION) VALUES ('History of Magic', 'The lesson plan usually consists of lectures on the History of Wizards and the  Magical World. The history of magic is taught by the ghost of Professor Cuthbert Binns.')
INSERT INTO COURSES (NAME, DESCRIPTION) VALUES ('Flying', 'Flying, also known as the broom flying class, is a subject taught at Hogwarts  School of Witchcraft and Wizardry. This subject teaches STUDENTS how to fly on broomsticks. Flying is taught by Madam Hooch.')
GO

INSERT INTO GROUPS (COURSE_ID, NAME) VALUES ('1', 'SR-01')
INSERT INTO GROUPS (COURSE_ID, NAME) VALUES ('4', 'SR-02')
INSERT INTO GROUPS (COURSE_ID, NAME) VALUES ('2', 'SR-03')
INSERT INTO GROUPS (COURSE_ID, NAME) VALUES ('5', 'SR-04')
INSERT INTO GROUPS (COURSE_ID, NAME) VALUES ('3', 'SR-05')
GO

INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Lucius', 'Malfoy')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Tom', 'Riddle')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Percy', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Bill', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Charlie', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Fred', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Hermione', 'Granger')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'George', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Ron', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Angelina', 'Johnson')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Molly', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Arthur', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'James', 'Potter')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('1', 'Moaning', 'Myrtle')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Alicia', 'Spinnet')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Patricia', 'Stimpson')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Madeline', 'Cyr')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Kenneth', 'Towler')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Zacharias', 'Smith')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Lily', 'Potter')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Blaise', 'Zabini')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Hermione', 'Granger')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Draco', 'Malfoy')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Dean', 'Thomas')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Millicent', 'Bulstrode')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Terry', 'Boot')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Ernie', 'Macmillan')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Vincent', 'Crabbe')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Gregory', 'Goyle')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('3', 'Lavender', 'Brown')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Katie', 'Bell')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Parvati', 'Patil')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Dennis', 'Creevey')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Eloise', 'Midgen')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Ritchie', 'Coote')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Jack', 'Sloper')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Victoria', 'Frobisher')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Pansy', 'Parkinson')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Hannah', 'Abbott')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Seamus', 'Finnigan')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Colin', 'Creevey')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Harry', 'Potter')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Geoffrey', 'Hooper')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('5', 'Andrew', 'Kirke')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Demelza', 'Robins')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Cormac', 'McLaggen')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Neville', 'Longbottom')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Ginny', 'Weasley')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Romilda', 'Vane')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Natalie', 'McDonald')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Jimmy', 'Peakes')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Hermione', 'Granger')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Euan', 'Abercrombie')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Mary', 'MacDonald')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Penelope', 'Clearwater')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Roger', 'Davies')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Eddie', 'Carmichael')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Cho', 'Chang')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('4', 'Padma', 'Patil')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Marietta', 'Edgecombe')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Mandy', 'Brocklehurst')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Michael', 'Corner')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Stephen', 'Cornfoot')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Kevin', 'Entwhistle')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Anthony', 'Goldstein')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Su', 'Li')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Morag', 'McDougal')
INSERT INTO STUDENTS (GROUP_ID, FIRST_NAME, LAST_NAME) VALUES ('2', 'Hermione', 'Granger')
GO