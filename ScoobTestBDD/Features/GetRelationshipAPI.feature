Feature: GetRelationshipAPI

This feature tests the API requests for getting a relationship.  This is tested
with the seed data for get all relationships and non-seed data for get a specific
relationship.

@API
Scenario: Gets all relationships utilizing the API and verify seed data is accurate
	Given I get all relationships through the API
	Then I can verify the data exists for the following data
	| Name                     | Relationship   | Apperance                                                                                                                          | Gang   |
	| Dave Walton              | Uncle          | {"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":3,"EPISODE":1,"RELEASE_YEAR":1978}],"Movie":[{}],"APPEARED":true}"            | Velma  |
	| Scrappy-Doo              | Nephew         | "{"TV":[{}],"Movie":[{"NAME":"Scooby-Doo", "RELEASE_YEAR":2002}],"APPEARED":true}"                                                 | Scooby |
	| John Maxwell             | Uncle          | "{"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":1,"EPISODE":7,"RELEASE_YEAR":1969}],"Movie":[{}],"APPEARED":true}"           | Daphne |
	| Olivia Dervy             | Aunt           | "{"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":3,"EPISODE":9,"RELEASE_YEAR":1978}],"Movie":[{}],"APPEARED":true}"           | Daphne |
	| Skip Jones               | Uncle          | "{"TV":[{}],"Movie":[{"NAME":"Scoob-Doo! Pirates Ahoy!", "RELEASE_YEAR":2006}],"APPEARED":true}"                                   | Fred   |
	| Margaret 'Maggie' Rogers | Younger Sister | "{"TV":[{"SHOW":"The New Scooby and Scrappy Doo Show","SEASON":1,"EPISODE":13,"RELEASE_YEAR":1983}],"Movie":[{}],"APPEARED":true}" | Shaggy |

@API
Scenario: Gets a specific relationship by Name through the API and verify the seed data for Dave Walton is accurate
	Given I get a relationship through the API with the name Dave Walton
	Then I can verify the data exists for the following data
	| Name        | Relationship | Apperance                                                                                                               | Gang  |
	| Dave Walton | Uncle        | {"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":3,"EPISODE":1,"RELEASE_YEAR":1978}],"Movie":[{}],"APPEARED":true}" | Velma |

@API
Scenario: Gets a specific relationship by Name through the API and verify the seed data for Scrappy-Doo is accurate
	Given I get a relationship through the API with the name Scrappy-Doo
	Then I can verify the data exists for the following data
	| Name        | Relationship | Apperance                                                                          | Gang   |
	| Scrappy-Doo | Nephew       | "{"TV":[{}],"Movie":[{"NAME":"Scooby-Doo", "RELEASE_YEAR":2002}],"APPEARED":true}" | Scooby |

@API
Scenario: Gets a specific relationship by Name through the API and verify the seed data for John Maxwell is accurate
	Given I get a relationship through the API with the name John Maxwell
	Then I can verify the data exists for the following data
	| John Maxwell | Uncle | "{"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":1,"EPISODE":7,"RELEASE_YEAR":1969}],"Movie":[{}],"APPEARED":true}" | Daphne |

@API
Scenario: Gets a specific relationship by Name through the API and verify the seed data for Olivia Dervy is accurate
	Given I get a relationship through the API with the name Olivia Dervy
	Then I can verify the data exists for the following data
	| Olivia Dervy | Aunt | "{"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":3,"EPISODE":9,"RELEASE_YEAR":1978}],"Movie":[{}],"APPEARED":true}" | Daphne |

@API
Scenario: Gets a specific relationship by Name through the API and verify the seed data for Skip Jones is accurate
	Given I get a relationship through the API with the name Skip Jones
	Then I can verify the data exists for the following data
	| Skip Jones | Uncle | "{"TV":[{}],"Movie":[{"NAME":"Scoob-Doo! Pirates Ahoy!", "RELEASE_YEAR":2006}],"APPEARED":true}" | Fred |

@API
Scenario: Gets a specific relationship by Name through the API and verify the seed data for Margaret 'Maggie' Rogers is accurate
	Given I get a relationship through the API with the name Margaret 'Maggie' Rogers
	Then I can verify the data exists for the following data
	| Margaret 'Maggie' Rogers | Younger Sister | "{"TV":[{"SHOW":"The New Scooby and Scrappy Doo Show","SEASON":1,"EPISODE":13,"RELEASE_YEAR":1983}],"Movie":[{}],"APPEARED":true}" | Shaggy |

@API
Scenario: Gets a specific relationship by ID through the API and verify the seed data for Dave Walton is accurate
	Given I get a relationship through the API with the id 1
	Then I can verify the data exists for the following data
	| Name        | Relationship | Apperance                                                                                                               | Gang  |
	| Dave Walton | Uncle        | {"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":3,"EPISODE":1,"RELEASE_YEAR":1978}],"Movie":[{}],"APPEARED":true}" | Velma |

@API
Scenario: Gets a specific relationship by ID through the API and verify the seed data for Scrappy-Doo is accurate
	Given I get a relationship through the API with the id 2
	Then I can verify the data exists for the following data
	| Name        | Relationship | Apperance                                                                          | Gang   |
	| Scrappy-Doo | Nephew       | "{"TV":[{}],"Movie":[{"NAME":"Scooby-Doo", "RELEASE_YEAR":2002}],"APPEARED":true}" | Scooby |

@API
Scenario: Gets a specific relationship by ID through the API and verify the seed data for John Maxwell is accurate
	Given I get a relationship through the API with the id 3
	Then I can verify the data exists for the following data
	| John Maxwell | Uncle | "{"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":1,"EPISODE":7,"RELEASE_YEAR":1969}],"Movie":[{}],"APPEARED":true}" | Daphne |

@API
Scenario: Gets a specific relationship by ID through the API and verify the seed data for Olivia Dervy is accurate
	Given I get a relationship through the API with the id 4
	Then I can verify the data exists for the following data
	| Olivia Dervy | Aunt | "{"TV":[{"SHOW":"Scooby-Doo, Where Are You!","SEASON":3,"EPISODE":9,"RELEASE_YEAR":1978}],"Movie":[{}],"APPEARED":true}" | Daphne |

@API
Scenario: Gets a specific relationship by ID through the API and verify the seed data for Skip Jones is accurate
	Given I get a relationship through the API with the id 5
	Then I can verify the data exists for the following data
	| Skip Jones | Uncle | "{"TV":[{}],"Movie":[{"NAME":"Scoob-Doo! Pirates Ahoy!", "RELEASE_YEAR":2006}],"APPEARED":true}" | Fred |

@API
Scenario: Gets a specific relationship by ID through the API and verify the seed data for Margaret 'Maggie' Rogers is accurate
	Given I get a relationship through the API with the id 6
	Then I can verify the data exists for the following data
	| Margaret 'Maggie' Rogers | Younger Sister | "{"TV":[{"SHOW":"The New Scooby and Scrappy Doo Show","SEASON":1,"EPISODE":13,"RELEASE_YEAR":1983}],"Movie":[{}],"APPEARED":true}" | Shaggy |
