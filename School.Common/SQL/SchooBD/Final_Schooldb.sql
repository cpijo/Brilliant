
Create Database schooldb;
use schooldb;
go

	CREATE TABLE GradeTeacher
	(
    TeacherId varchar(50)  NOT NULL,
    GradeId varchar(50)  NOT NULL,
	CreatedDate  DATETIME NOT NULL,
	UpdatedDate  DATETIME NOT NULL
	)

	INSERT INTO GradeTeacher(TeacherId,GradeId ,CreatedDate ,UpdatedDate) values('TC00000008','Grade8' ,'09/11/2021','09/11/2021');
	INSERT INTO GradeTeacher(TeacherId,GradeId ,CreatedDate ,UpdatedDate) values('TC00000009','Grade9' ,'09/11/2021','09/11/2021');
	INSERT INTO GradeTeacher(TeacherId,GradeId ,CreatedDate ,UpdatedDate) values('TC00000010','Grade10','09/11/2021','09/11/2021');
	INSERT INTO GradeTeacher(TeacherId,GradeId ,CreatedDate ,UpdatedDate) values('TC00000011','Grade11','09/11/2021','09/11/2021');
	INSERT INTO GradeTeacher(TeacherId,GradeId ,CreatedDate ,UpdatedDate) values('TC00000012','Grade12','09/11/2021','09/11/2021');

	CREATE TABLE ClassTeacher
	(
    TeacherId varchar(50)  NOT NULL,
    ClassId varchar(50)  NOT NULL,
	CreatedDate  DATETIME NOT NULL,
	UpdatedDate  DATETIME NOT NULL
	)

	INSERT INTO ClassTeacher(TeacherId,ClassId ,CreatedDate ,UpdatedDate) values('TC00000008','ClassSie008','09/11/2021','09/11/2021');
	INSERT INTO ClassTeacher(TeacherId,ClassId ,CreatedDate ,UpdatedDate) values('TC00000009','ClassSie009','09/11/2021','09/11/2021');
	INSERT INTO ClassTeacher(TeacherId,ClassId ,CreatedDate ,UpdatedDate) values('TC00000010','ClassSie010','09/11/2021','09/11/2021');
	INSERT INTO ClassTeacher(TeacherId,ClassId ,CreatedDate ,UpdatedDate) values('TC00000011','ClassSie011','09/11/2021','09/11/2021');
	INSERT INTO ClassTeacher(TeacherId,ClassId ,CreatedDate ,UpdatedDate) values('TC00000012','ClassSie012','09/11/2021','09/11/2021');

	CREATE TABLE Teaching
	(
     TeacherId  varchar(50) NOT NULL,
	 SubjectId varchar(50) NOT NULL,
	 ClassId varchar(50) NOT NULL,
	 GradeId varchar(50) NOT NULL ,
     PRIMARY KEY (TeacherId,GradeId,ClassId,SubjectId),
	 )

	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000008','Eng008','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000008','Ven008','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000008','Sie008','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000008','Mat008','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000008','Bio008','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000008','Geo008','ClassSie009','Grade008');

	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000009','Eng009','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000009','Ven009','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000009','Sie009','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000009','Mat009','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000009','Bio009','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000009','Geo009','ClassSie009','Grade008');

	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000010','Eng010','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000010','Ven010','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000010','Sie010','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000010','Mat010','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000010','Bio010','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000010','Geo010','ClassSie009','Grade008');

	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000011','Eng011','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000011','Ven011','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000011','Sie011','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000011','Mat011','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000011','Bio011','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000011','Geo011','ClassSie009','Grade008');

	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000012','Eng012','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000012','Ven012','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000012','Sie012','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000012','Mat012','ClassSie009','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000012','Bio012','ClassSie008','Grade008');
	INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values('TC00000012','Geo012','ClassSie009','Grade008');

	CREATE TABLE GradeStudent
    (
    GradeStudentId  int IDENTITY(1,1), --PRIMARY KEY,
	StudentId varchar(50) NOT NULL ,
	GradeId varchar(50) NOT NULL,
    CreatedDate datetime NULL ,
  	PRIMARY KEY (GradeStudentId,StudentId,GradeId)
	);

	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST08000001','Grade8','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST08000002','Grade8','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST08000003','Grade8','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST08000004','Grade8','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST08000005','Grade8','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST08000006','Grade8','2020-10-10');

	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST09000001','Grade9','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST09000002','Grade9','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST09000003','Grade9','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST09000004','Grade9','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST09000005','Grade9','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST09000006','Grade9','2020-10-10');

	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST10000001','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST10000002','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST10000003','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST10000004','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST10000005','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST10000006','Grade12','2020-10-10');

	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST11000001','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST11000002','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST11000003','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST11000004','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST11000005','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST11000006','Grade12','2020-10-10');

	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST12000001','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST12000002','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST12000003','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST12000004','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST12000005','Grade12','2020-10-10');
	INSERT INTO GradeStudent(StudentId,GradeId ,CreatedDate) values('ST12000006','Grade12','2020-10-10');


	
	CREATE TABLE Grade(
    GradeId varchar(50) NOT NULL,
    GradeName varchar(50) NOT NULL 
     PRIMARY KEY (GradeId)
    );

    INSERT INTO Grade(GradeId,GradeName) values('Grade8','Grade 8');
    INSERT INTO Grade(GradeId,GradeName) values('Grade9','Grade 9');
    INSERT INTO Grade(GradeId,GradeName) values('Grade10','Grade 10');
    INSERT INTO Grade(GradeId,GradeName) values('Grade11','Grade 11');
    INSERT INTO Grade(GradeId,GradeName) values('Grade12','Grade 12');
     
	 CREATE TABLE GradeClass(
     GradeId varchar(50) NOT NULL,
     ClassId varchar(50) NOT NULL,
     GradeName varchar(50) NOT NULL ,--remove
     PRIMARY KEY (GradeId, ClassId),
	 FOREIGN KEY (GradeId) REFERENCES Grade(GradeId)
	 --FOREIGN KEY (ClassId) REFERENCES Class(ClassId),
    );

    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade8','ClassEng008','Grade 8');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade8','ClassVen008','Grade 8');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade8','ClassSie008','Grade 8');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade8','ClassMat008','Grade 8');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade8','ClassBio008','Grade 8');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade8','ClassGeo008','Grade 8');

    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade9','ClassEng009','Grade 9');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade9','ClassVen009','Grade 9');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade9','ClassSie009','Grade 9');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade9','ClassMat009','Grade 9');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade9','ClassBio009','Grade 9');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade9','ClassGeo009','Grade 9');

    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade10','ClassEng010','Grade 10');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade10','ClassVen010','Grade 10');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade10','ClassSie010','Grade 10');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade10','ClassMat010','Grade 10');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade10','ClassBio010','Grade 10');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade10','ClassGeo010','Grade 10');

	INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade11','ClassEng011','Grade 11');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade11','ClassVen011','Grade 11');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade11','ClassSie011','Grade 11');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade11','ClassMat011','Grade 11');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade11','ClassBio011','Grade 11');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade11','ClassGeo011','Grade 11');

	INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade12','ClassEng012','Grade 12');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade12','ClassVen012','Grade 12');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade12','ClassSie012','Grade 12');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade12','ClassMat012','Grade 12');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade12','ClassBio012','Grade 12');
    INSERT INTO GradeClass(GradeId,ClassId,GradeName) values('Grade12','ClassGeo012','Grade 12');


	create table Subject
    (
    SubjectId varchar(50)  NOT NULL ,
    SubjectName varchar(50) NOT NULL ,
    PRIMARY KEY (SubjectId)
    );

	INSERT INTO subject(subjectid,subjectname) values('Eng008','English');
	INSERT INTO subject(subjectid,subjectname) values('Ven008','Venda');
	INSERT INTO subject(subjectid,subjectname) values('Sie008','Physical Sience');
	INSERT INTO subject(subjectid,subjectname) values('Mat008','Mathematics');
	INSERT INTO subject(subjectid,subjectname) values('Bio008','Biology');
	INSERT INTO subject(subjectid,subjectname) values('Geo008','Geology');

	INSERT INTO subject(subjectid,subjectname) values('Eng009','English');
	INSERT INTO subject(subjectid,subjectname) values('Ven009','Venda');
	INSERT INTO subject(subjectid,subjectname) values('Sie009','Physical Sience');
	INSERT INTO subject(subjectid,subjectname) values('Mat009','Mathematics');
	INSERT INTO subject(subjectid,subjectname) values('Bio009','Biology');
	INSERT INTO subject(subjectid,subjectname) values('Geo009','Geology');

	INSERT INTO subject(subjectid,subjectname) values('Eng010','English');
	INSERT INTO subject(subjectid,subjectname) values('Ven010','Venda');
	INSERT INTO subject(subjectid,subjectname) values('Sie010','Physical Sience');
	INSERT INTO subject(subjectid,subjectname) values('Mat010','Mathematics');
	INSERT INTO subject(subjectid,subjectname) values('Bio010','Biology');
	INSERT INTO subject(subjectid,subjectname) values('Geo010','Geology');

	INSERT INTO subject(subjectid,subjectname) values('Eng011','English');
	INSERT INTO subject(subjectid,subjectname) values('Ven011','Venda');
	INSERT INTO subject(subjectid,subjectname) values('Sie011','Physical Sience');
	INSERT INTO subject(subjectid,subjectname) values('Mat011','Mathematics');
	INSERT INTO subject(subjectid,subjectname) values('Bio011','Biology');
	INSERT INTO subject(subjectid,subjectname) values('Geo011','Geology');

	INSERT INTO subject(subjectid,subjectname) values('Eng012','English');
	INSERT INTO subject(subjectid,subjectname) values('Ven012','Venda');
	INSERT INTO subject(subjectid,subjectname) values('Sie012','Physical Sience');
	INSERT INTO subject(subjectid,subjectname) values('Mat012','Mathematics');
	INSERT INTO subject(subjectid,subjectname) values('Bio012','Biology');
	INSERT INTO subject(subjectid,subjectname) values('Geo012','Geology');

	CREATE TABLE Class(
     ClassId varchar(50) NOT NULL,
     ClassName varchar(50) NOT NULL ,--change ti name
     PRIMARY KEY (ClassId)
    );


 	INSERT INTO Class(ClassId,ClassName) values('ClassSie008','Sience Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassBus008','Business Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassHis008','History Class');

	INSERT INTO Class(ClassId,ClassName) values('ClassSie009','Sience Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassBus009','Business Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassHis009','History Class');

	INSERT INTO Class(ClassId,ClassName) values('ClassSie010','Sience Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassBus010','Business Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassHis010','History Class');

	INSERT INTO Class(ClassId,ClassName) values('ClassSie011','Sience Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassBus011','Business Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassHis011','History Class');

	INSERT INTO Class(ClassId,ClassName) values('ClassSie012','Sience Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassBus012','Business Class');
	INSERT INTO Class(ClassId,ClassName) values('ClassHis012','History Class');


	CREATE TABLE ClassSubject(
     ClassSubjectId int IDENTITY(1,1),
	 ClassId varchar(50) NOT NULL,
	 SubjectId varchar(50) NOT NULL,
	 SubjectName varchar(50) NOT NULL ,--remove
	  PRIMARY KEY (ClassId,SubjectId)
	 --FOREIGN KEY (ClassId) REFERENCES Class(ClassId)
	 --FOREIGN KEY (SubjectId) REFERENCES Subject(SubjectId)
    );

	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassEng008','Eng008','English');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassVen008','Ven008','Venda');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie008','Sie008','Physical Sience');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassMat008','Mat008','Mathematics');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassBio008','Bio008','Biology');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassGeo008','Geo008','Geology');

	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassEng009','Eng009','English');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassVen009','Ven009','Venda');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie009','Sie009','Physical Sience');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassMat009','Mat009','Mathematics');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassBio009','Bio009','Biology');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassGeo009','Geo009','Geology');

	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassEng010','Eng010','English');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassVen010','Ven010','Venda');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie010','Sie010','Physical Sience');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassMat010','Mat010','Mathematics');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassBio010','Bio010','Biology');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassGeo010','Geo010','Geology');

	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassEng011','Eng011','English');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassVen011','Ven011','Venda');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie011','Sie011','Physical Sience');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassMat011','Mat011','Mathematics');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassBio011','Bio011','Biology');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassGeo011','Geo011','Geology');

	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassEng012','Eng012','English');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassVen012','Ven012','Venda');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie012','Sie012','Physical Sience');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassMat012','Mat012','Mathematics');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassBio012','Bio012','Biology');
	 INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassGeo012','Geo012','Geology');

	
	--CREATE TABLE ClassSubject(
 --    ClassSubjectId int IDENTITY(1,1),
	-- ClassId varchar(50) NOT NULL,
	-- SubjectId varchar(50) NOT NULL,
	-- SubjectName varchar(50) NOT NULL ,
	-- FOREIGN KEY (ClassId) REFERENCES Class(ClassId),
	-- FOREIGN KEY (SubjectId) REFERENCES Subject(SubjectId)
 --   );

	--INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie008','Sie008','Science');
	--INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie009','Sie009','Science');
	--INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie010','Sie010','Science');
	--INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie011','Sie011','Science');
	--INSERT INTO ClassSubject(ClassId,SubjectId,SubjectName) values('ClassSie012','Sie012','Science');

--@@@@@@@@@@@@@@

	CREATE TABLE RegisteredGrade(
	RegisteredId int IDENTITY(1,1),
	StudentId varchar(50) NOT NULL,
    GradeId varchar(50) NOT NULL,
    CreatedDate datetime NOT NULL
     PRIMARY KEY (StudentId,GradeId)
    );

	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST08000001','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST08000002','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST08000003','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST08000004','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST08000005','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST08000006','Grade12','2020-10-10');

	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST09000001','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST09000002','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST09000003','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST09000004','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST09000005','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST09000006','Grade12','2020-10-10');

	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST10000001','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST10000002','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST10000003','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST10000004','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST10000005','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST10000006','Grade12','2020-10-10');

	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST11000001','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST11000002','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST11000003','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST11000004','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST11000005','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST11000006','Grade12','2020-10-10');

	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST12000001','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST12000002','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST12000003','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST12000004','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST12000005','Grade12','2020-10-10');
	INSERT INTO RegisteredGrade(studentid,GradeId ,CreatedDate) values('ST12000006','Grade12','2020-10-10');



	CREATE TABLE StudentTeacher
	(
    TeacherId varchar(50)  NOT NULL,
    StudentId varchar(50)  NOT NULL,
	CreatedDate  DATETIME NOT NULL,
	UpdatedDate  DATETIME NOT NULL
	)

	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000008','ST08000001','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000008','ST08000002','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000008','ST08000003','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000008','ST08000004','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000008','ST08000005','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000008','ST08000006','09/11/2021','09/11/2021');

	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000009','ST09000001','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000009','ST09000002','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000009','ST09000003','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000009','ST09000004','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000009','ST09000005','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC00000009','ST09000006','09/11/2021','09/11/2021');

	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC10000008','ST10000001','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC10000008','ST10000002','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC10000008','ST10000003','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC10000008','ST10000004','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC10000008','ST10000005','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC10000008','ST10000006','09/11/2021','09/11/2021');

	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC11000008','ST11000001','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC11000008','ST11000002','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC11000008','ST11000003','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC11000008','ST11000004','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC11000008','ST11000005','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC11000008','ST11000006','09/11/2021','09/11/2021');

	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC12000008','ST12000001','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC12000008','ST12000002','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC12000008','ST12000003','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC12000008','ST12000004','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC12000008','ST12000005','09/11/2021','09/11/2021');
	INSERT INTO StudentTeacher(TeacherId,StudentId ,CreatedDate ,UpdatedDate) values('TC12000008','ST12000006','09/11/2021','09/11/2021');



	CREATE TABLE StudentMarks(
	 StudentScoreId int IDENTITY(1,1),
     StudentId varchar(50) NOT NULL, 
	 GradeId varchar(50) NOT NULL, 
     ExamType varchar(50) NOT NULL, 
     SubjectId varchar(50) NOT NULL, 
     MarkValue int NOT NULL,
     PRIMARY KEY (StudentScoreId,StudentId,GradeId,SubjectId)
    );

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000001','Grade8','Quater 1','Eng008',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000001','Grade8','Quater 1','Ven008',70);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000001','Grade8','Quater 1','Sie008',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000001','Grade8','Quater 1','Mat008',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000001','Grade8','Quater 1','Bio008',81);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000001','Grade8','Quater 1','Geo008',72);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000002','Grade8','Quater 1','Eng008',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000002','Grade8','Quater 1','Ven008',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000002','Grade8','Quater 1','Sie008',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000002','Grade8','Quater 1','Mat008',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000002','Grade8','Quater 1','Bio008',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000002','Grade8','Quater 1','Geo008',72);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000003','Grade8','Quater 1','Eng008',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000003','Grade8','Quater 1','Ven008',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000003','Grade8','Quater 1','Sie008',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000003','Grade8','Quater 1','Mat008',93);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000003','Grade8','Quater 1','Bio008',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000003','Grade8','Quater 1','Geo008',73);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000004','Grade8','Quater 1','Eng008',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000004','Grade8','Quater 1','Ven008',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000004','Grade8','Quater 1','Sie008',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000004','Grade8','Quater 1','Mat008',94);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000004','Grade8','Quater 1','Bio008',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000004','Grade8','Quater 1','Geo008',74);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000005','Grade8','Quater 1','Eng008',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000005','Grade8','Quater 1','Ven008',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000005','Grade8','Quater 1','Sie008',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000005','Grade8','Quater 1','Mat008',95);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000005','Grade8','Quater 1','Bio008',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000005','Grade8','Quater 1','Geo008',75);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000006','Grade8','Quater 1','Eng008',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000006','Grade8','Quater 1','Ven008',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000006','Grade8','Quater 1','Sie008',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000006','Grade8','Quater 1','Mat008',96);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000006','Grade8','Quater 1','Bio008',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST08000006','Grade8','Quater 1','Geo008',76);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000001','Grade09','Quater 1','Eng009',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000001','Grade09','Quater 1','Ven009',70);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000001','Grade09','Quater 1','Sie009',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000001','Grade09','Quater 1','Mat009',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000001','Grade09','Quater 1','Bio009',81);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000001','Grade09','Quater 1','Geo009',72);
																													  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000002','Grade09','Quater 1','Eng009',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000002','Grade09','Quater 1','Ven009',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000002','Grade09','Quater 1','Sie009',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000002','Grade09','Quater 1','Mat009',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000002','Grade09','Quater 1','Bio009',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000002','Grade09','Quater 1','Geo009',72);
																													 		
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000003','Grade09','Quater 1','Eng009',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000003','Grade09','Quater 1','Ven009',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000003','Grade09','Quater 1','Sie009',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000003','Grade09','Quater 1','Mat009',93);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000003','Grade09','Quater 1','Bio009',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000003','Grade09','Quater 1','Geo009',73);
																													  		
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000004','Grade09','Quater 1','Eng009',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000004','Grade09','Quater 1','Ven009',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000004','Grade09','Quater 1','Sie009',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000004','Grade09','Quater 1','Mat009',94);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000004','Grade09','Quater 1','Bio009',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000004','Grade09','Quater 1','Geo009',74);
																													   	
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000005','Grade09','Quater 1','Eng009',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000005','Grade09','Quater 1','Ven009',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000005','Grade09','Quater 1','Sie009',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000005','Grade09','Quater 1','Mat009',95);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000005','Grade09','Quater 1','Bio009',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000005','Grade09','Quater 1','Geo009',75);
																													   		
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000006','Grade09','Quater 1','Eng009',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000006','Grade09','Quater 1','Ven009',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000006','Grade09','Quater 1','Sie009',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000006','Grade09','Quater 1','Mat009',96);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000006','Grade09','Quater 1','Bio009',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST09000006','Grade09','Quater 1','Geo009',76);


	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000001','Grade10','Quater 1','Eng010',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000001','Grade10','Quater 1','Ven010',70);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000001','Grade10','Quater 1','Sie010',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000001','Grade10','Quater 1','Mat010',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000001','Grade10','Quater 1','Bio010',81);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000001','Grade10','Quater 1','Geo010',72);
																					
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000002','Grade10','Quater 1','Eng010',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000002','Grade10','Quater 1','Ven010',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000002','Grade10','Quater 1','Sie010',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000002','Grade10','Quater 1','Mat010',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000002','Grade10','Quater 1','Bio010',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000002','Grade10','Quater 1','Geo010',72);
																														  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000003','Grade10','Quater 1','Eng010',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000003','Grade10','Quater 1','Ven010',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000003','Grade10','Quater 1','Sie010',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000003','Grade10','Quater 1','Mat010',93);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000003','Grade10','Quater 1','Bio010',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000003','Grade10','Quater 1','Geo010',73);
																					 									  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000004','Grade10','Quater 1','Eng010',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000004','Grade10','Quater 1','Ven010',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000004','Grade10','Quater 1','Sie010',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000004','Grade10','Quater 1','Mat010',94);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000004','Grade10','Quater 1','Bio010',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000004','Grade10','Quater 1','Geo010',74);
																					 									 
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000005','Grade10','Quater 1','Eng010',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000005','Grade10','Quater 1','Ven010',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000005','Grade10','Quater 1','Sie010',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000005','Grade10','Quater 1','Mat010',95);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000005','Grade10','Quater 1','Bio010',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000005','Grade10','Quater 1','Geo010',75);
																					  									 
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000006','Grade10','Quater 1','Eng010',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000006','Grade10','Quater 1','Ven010',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000006','Grade10','Quater 1','Sie010',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000006','Grade10','Quater 1','Mat010',96);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000006','Grade10','Quater 1','Bio010',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST10000006','Grade10','Quater 1','Geo010',76);


	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000001','Grade11','Quater 1','Eng011',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000001','Grade11','Quater 1','Ven011',70);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000001','Grade11','Quater 1','Sie011',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000001','Grade11','Quater 1','Mat011',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000001','Grade11','Quater 1','Bio011',81);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000001','Grade11','Quater 1','Geo011',72);
																					
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000002','Grade11','Quater 1','Eng011',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000002','Grade11','Quater 1','Ven011',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000002','Grade11','Quater 1','Sie011',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000002','Grade11','Quater 1','Mat011',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000002','Grade11','Quater 1','Bio011',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000002','Grade11','Quater 1','Geo011',72);
																														  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000003','Grade11','Quater 1','Eng011',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000003','Grade11','Quater 1','Ven011',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000003','Grade11','Quater 1','Sie011',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000003','Grade11','Quater 1','Mat011',93);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000003','Grade11','Quater 1','Bio011',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000003','Grade11','Quater 1','Geo011',73);
																					 									  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000004','Grade11','Quater 1','Eng011',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000004','Grade11','Quater 1','Ven011',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000004','Grade11','Quater 1','Sie011',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000004','Grade11','Quater 1','Mat011',94);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000004','Grade11','Quater 1','Bio011',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000004','Grade11','Quater 1','Geo011',74);
																					 									  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000005','Grade11','Quater 1','Eng011',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000005','Grade11','Quater 1','Ven011',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000005','Grade11','Quater 1','Sie011',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000005','Grade11','Quater 1','Mat011',95);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000005','Grade11','Quater 1','Bio011',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000005','Grade11','Quater 1','Geo011',75);
																					  									  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000006','Grade11','Quater 1','Eng011',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000006','Grade11','Quater 1','Ven011',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000006','Grade11','Quater 1','Sie011',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000006','Grade11','Quater 1','Mat011',96);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000006','Grade11','Quater 1','Bio011',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST11000006','Grade11','Quater 1','Geo011',76);

	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000001','Grade12','Quater 1','Eng012',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000001','Grade12','Quater 1','Ven012',70);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000001','Grade12','Quater 1','Sie012',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000001','Grade12','Quater 1','Mat012',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000001','Grade12','Quater 1','Bio012',81);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000001','Grade12','Quater 1','Geo012',72);
																														  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000002','Grade12','Quater 1','Eng012',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000002','Grade12','Quater 1','Ven012',72);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000002','Grade12','Quater 1','Sie012',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000002','Grade12','Quater 1','Mat012',92);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000002','Grade12','Quater 1','Bio012',82);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000002','Grade12','Quater 1','Geo012',72);
																														
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000003','Grade12','Quater 1','Eng012',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000003','Grade12','Quater 1','Ven012',73);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000003','Grade12','Quater 1','Sie012',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000003','Grade12','Quater 1','Mat012',93);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000003','Grade12','Quater 1','Bio012',83);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000003','Grade12','Quater 1','Geo012',73);
																					 									
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000004','Grade12','Quater 1','Eng012',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000004','Grade12','Quater 1','Ven012',74);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000004','Grade12','Quater 1','Sie012',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000004','Grade12','Quater 1','Mat012',94);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000004','Grade12','Quater 1','Bio012',84);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000004','Grade12','Quater 1','Geo012',74);
																					 									 
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000005','Grade12','Quater 1','Eng012',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000005','Grade12','Quater 1','Ven012',75);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000005','Grade12','Quater 1','Sie012',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000005','Grade12','Quater 1','Mat012',95);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000005','Grade12','Quater 1','Bio012',85);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000005','Grade12','Quater 1','Geo012',75);
																														  
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000006','Grade12','Quater 1','Eng012',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000006','Grade12','Quater 1','Ven012',76);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000006','Grade12','Quater 1','Sie012',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000006','Grade12','Quater 1','Mat012',96);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000006','Grade12','Quater 1','Bio012',86);
	INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue) values('ST12000006','Grade12','Quater 1','Geo012',76);
																										

    create table ExamTypes
    (
    ExamId varchar(50)  NOT NULL ,
    ExamName varchar(50) NOT NULL , 
    QuaterName varchar(50) NULL ,
    PRIMARY KEY (ExamId)
    );
	
	INSERT INTO ExamTypes(ExamId,ExamName,QuaterName) values('Q108001','Quater One','Quater 1');
    INSERT INTO ExamTypes(ExamId,ExamName,QuaterName) values('Q208001','Quater Two','Quater 2');
    INSERT INTO ExamTypes(ExamId,ExamName,QuaterName) values('Q308001','Quater Three','Quater 3');
    INSERT INTO ExamTypes(ExamId,ExamName,QuaterName) values('FL08001','Final','Final');
	INSERT INTO ExamTypes(ExamId,ExamName,QuaterName) values('WK08001','Weekly','Weekly');
	INSERT INTO ExamTypes(ExamId,ExamName,QuaterName) values('MT08001','Monthly','Monthly');

    create table ExamQuarter
    (
    ExamId varchar(50)  NOT NULL ,
    ExamName varchar(50) NOT NULL , 
    QuaterName varchar(50) NULL ,
    ExamDate varchar(20) NULL ,
    PRIMARY KEY (ExamId)
    );
     
    INSERT INTO ExamQuarter(ExamId,ExamName,QuaterName,ExamDate) values('Q108001','Quater One','Quater 1','09/11/2021');
    INSERT INTO ExamQuarter(ExamId,ExamName,QuaterName,ExamDate) values('Q208001','Quater Two','Quater 2','09/11/2021');
    INSERT INTO ExamQuarter(ExamId,ExamName,QuaterName,ExamDate) values('Q308001','Quater Three','Quater 3','09/11/2021');
    INSERT INTO ExamQuarter(ExamId,ExamName,QuaterName,ExamDate) values('FL08001','Final','Final','09/11/2021');
	INSERT INTO ExamQuarter(ExamId,ExamName,QuaterName,ExamDate) values('WK08001','Weekly','Weekly','09/11/2021');
	INSERT INTO ExamQuarter(ExamId,ExamName,QuaterName,ExamDate) values('MT08001','Monthly','Monthly','09/11/2021');


   CREATE TABLE Student
  (
    UserId varchar(50)  NOT NULL,
    UserName varchar(50)  NOT NULL,
    FirstName varchar(50)  NOT NULL,
    LastName varchar(50)  NOT NULL,
	Age int  NOT NULL,
    Gender varchar(10)  NOT NULL,
	Race varchar(20)  null,
	Languages varchar(20)  NULL,
	CreatedDate  DATETIME NOT NULL,
	UpdatedDate  DATETIME NOT NULL,
	Password  varchar(50) NOT NULL,
	PasswordResetCode varchar(50) NULL,
	LockoutEnabled INT NULL,
	AccessFailedCount INT NULL,
	IsLockedOut INT NULL,
	IsActive INT NOT NULL,
	LastLoginDate DATETIME  NULL,
	LastLockoutDate DATETIME  NULL,
	LastSeenDate DATETIME  NULL,
    UserType varchar(20)  NULL
	PRIMARY KEY (UserId)
	);

 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST08000001','ST08000001','Sphiwe','Maluleke',20,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST08000002','ST08000002','Ally','Manganyi',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST08000003','ST08000003','Ronny','Muvenda',18,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST08000004','ST08000004','Tshepo','Moloi',21,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST08000005','ST08000005','Noma','Kone',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST08000006','ST08000006','Cindy','Golden',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 

 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST09000001','ST09000001','Sphiwe9','Maluleke9',20,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST09000002','ST09000002','Ally9','Manganyi9',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST09000003','ST09000003','Ronny9','Muvenda9',18,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST09000004','ST09000004','Tshepo9','Moloi9',21,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST09000005','ST09000005','Noma9','Kone9',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST09000006','ST09000006','Cindy9','Golden9',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;



  INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST10000001','ST10000001','Sphiwe10','Maluleke10',20,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST10000002','ST10000002','Ally10','Manganyi10',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST10000003','ST10000003','Ronny10','Muvenda10',18,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST10000004','ST10000004','Tshepo10','Moloi10',21,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST10000005','ST10000005','Noma10','Kone10',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST10000006','ST10000006','Cindy10','Golden10',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;


  INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST11000001','ST11000001','Sphiwe11','Maluleke11',20,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST11000002','ST11000002','Ally11','Manganyi11',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST11000003','ST11000003','Ronny11','Muvenda11',18,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST11000004','ST11000004','Tshepo11','Moloi11',21,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST11000005','ST11000005','Noma11','Kone11',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST11000006','ST11000006','Cindy11','Golden11',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;


  INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST12000001','ST12000001','Sphiwe12','Maluleke12',20,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST12000002','ST12000002','Ally12','Manganyi12',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST12000003','ST12000003','Ronny12','Muvenda12',18,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST12000004','ST12000004','Tshepo12','Moloi12',21,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST12000005','ST12000005','Noma12','Kone12',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('ST12000006','ST12000006','Cindy12','Golden12',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;




   CREATE TABLE Teacher
  (
    UserId varchar(50)  NOT NULL,
    UserName varchar(50)  NOT NULL,
    FirstName varchar(50)  NOT NULL,
    LastName varchar(50)  NOT NULL,
	Age int  NOT NULL,
    Gender varchar(10)  NOT NULL,
	Race varchar(20)  null,
	Languages varchar(20)  NULL,
	CreatedDate  DATETIME NOT NULL,
	UpdatedDate  DATETIME NOT NULL,
	Password  varchar(50) NOT NULL,
	PasswordResetCode varchar(50) NULL,
	LockoutEnabled INT NULL,
	AccessFailedCount INT NULL,
	IsLockedOut INT NULL,
	IsActive INT NOT NULL,
	LastLoginDate DATETIME  NULL,
	LastLockoutDate DATETIME  NULL,
	LastSeenDate DATETIME  NULL,
    UserType varchar(20)  NULL
	PRIMARY KEY (UserId)
	);

 INSERT INTO Teacher(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('TC00000008','TC00000008','Sphiwe','Maluleke',30,'Male','Race','Tsonga','10/19/2021','10/19/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
 INSERT INTO Teacher(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('TC00000009','TC00000009','Ally','Manganyi',30,'Male','Race','Tsonga','10/19/2021','10/19/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Teacher(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('TC00000010','TC00000010','Ronny','Muvenda',30,'Male','Race','Tsonga','10/19/2021','10/19/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Teacher(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('TC00000011','TC00000011','Tshepo','Moloi',30,'Male','Race','Tsonga','10/19/2021','10/19/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
INSERT INTO Teacher(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
 values('TC00000012','TC00000012','Noma','Kone',30,'Male','Race','Tsonga','10/19/2021','10/19/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;


   CREATE TABLE Address
  (
    AddressId varchar(50)  NOT NULL,
    UserId varchar(50)  NOT NULL,
  	Country varchar(20)  NOT NULL,
	Province varchar(20)  NOT NULL,
	City varchar(20)  null,
    StreetAddress varchar(50)  NOT NULL,
    AddressCode varchar(50)  NOT NULL,
  )
     
	CREATE TABLE Contacts
   (  
      --ContactId varchar(50)  NOT NULL,
      UserID varchar(50)  NOT NULL,
      Phone varchar(50) NOT NULL,
      EmailAddress varchar(50) NULL
      PRIMARY KEY (UserID,Phone)
    )

	
  ALTER TABLE [schooldb].[dbo].[StudentMarks]
    ADD 
     ExamDate DATETIME NOT NULL DEFAULT '09/11/2021';