<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:msxsl="urn:schemas-microsoft-com:xslt" 
                xmlns:test="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
                exclude-result-prefixes="msxsl">

	<xsl:output method="html" version="5" doctype-system="" encoding="utf-8" />
	<xsl:strip-space elements="*" />

	<xsl:template match="test:TestRun">
		<html>
			<head>
				<title>Test Results</title>
				<style>
					table, th, td {
					border: 1px solid black;
					border-collapse: collapse;
					}
					th {
					text-align: left;
					}
					th, td {
					padding: 5px;
					}
					img {
					display: block;
					margin-left: auto;
					margin-right: auto;
					}
				</style>
			</head>

			<body style="font-family: Sans-Serif;font-size:12px">
				<h1>Test Results</h1>
				<table style="width:100%">
					<thead>
						<tr>
							<th/>
							<th>Name</th>
							<th>Error Message</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="./test:Results/test:UnitTestResult" />
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="test:UnitTestResult">
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="@outcome='Passed'">
						<img src="../../Assets/StatusOK.png" alt="Passed"/>
					</xsl:when>
					<xsl:when test="@outcome='Failed'">
						<img src="../../Assets/StatusBlocked.png" alt="Failed"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@outcome" />
					</xsl:otherwise>
				</xsl:choose>
			</td>
			<td>
				<xsl:value-of select="@testName" />
			</td>
			<td>
				<xsl:value-of select="./test:Output/test:ErrorInfo/test:Message" />
				<xsl:value-of select="./test:Output/test:ErrorInfo/test:StackTrace" />
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
