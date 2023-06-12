--
-- Create table `ss_tsaccount`
--
CREATE TABLE ss_tsaccount (
  AID BINARY(16) NOT NULL DEFAULT '' COMMENT 'UUID PK',
  Username VARCHAR(255) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL COMMENT 'User',
  Password VARCHAR(255) CHARACTER SET utf8mb3 COLLATE utf8_general_ci DEFAULT NULL COMMENT 'Password',
  PRIMARY KEY (AID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_as_ci;