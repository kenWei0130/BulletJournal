
CREATE SEQUENCE IF NOT EXISTS SEQ_BJ_TODO_ID START 1;
CREATE SEQUENCE IF NOT EXISTS SEQ_BJ_WORK_TARGET_ID START 1;

CREATE TABLE IF NOT EXISTS BJ_TODO (
    ID integer primary key default nextval('SEQ_BJ_TODO_ID'),
    WorkTitle varchar(20) not null,
    Description varchar(50),
    WorkRankID char(1) not null default '3',
    IsCompleted char(1) not null default '0',
    CreateDate varchar(8) not null default to_char(current_timestamp, 'YYYYMMDD'),
    TargetDate varchar(8) default to_char(current_timestamp, 'YYYYMMDD'),
    WorkTargetID integer 
);

insert into bj_todo(WorkTitle, Description, TargetDate) values('測試待辦一', '', '20211020');
insert into bj_todo(WorkTitle, Description, TargetDate) values('測試待辦二', '', '20211020');
insert into bj_todo(WorkTitle, Description, TargetDate) values('測試待辦三', '', '20211021');
insert into bj_todo(WorkTitle, Description, TargetDate) values('測試待辦四', '', '20211021');
insert into bj_todo(WorkTitle, WorkRankId, TargetDate) values('測試待辦五', '5', '20211021');
insert into bj_todo(WorkTitle, WorkRankId, TargetDate) values('測試待辦六', '1', '20211021');

CREATE TABLE IF NOT EXISTS BJ_WorkRank(
    ID CHAR(1) PRIMARY KEY NOT NULL,
    RankName varchar(10) not null default ''
);

INSERT INTO BJ_WorkRank(ID, RankName) VALUES('1', '非常低');
INSERT INTO BJ_WorkRank(ID, RankName) VALUES('2', '低');
INSERT INTO BJ_WorkRank(ID, RankName) VALUES('3', '一般');
INSERT INTO BJ_WorkRank(ID, RankName) VALUES('4', '高');
INSERT INTO BJ_WorkRank(ID, RankName) VALUES('5', '非常高');

CREATE TABLE IF NOT EXISTS BJ_WorkTarget(
    ID INTEGER PRIMARY KEY NOT NULL DEFAULT NEXTVAL('SEQ_BJ_WORK_TARGET_ID'),
    TargetDescription varchar(50) not null,
    TargetDate varchar(8) not null
);