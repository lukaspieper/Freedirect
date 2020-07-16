<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html" version="5" doctype-system="" encoding="utf-8" />
	<xsl:strip-space elements="*" />

	<xsl:template match="AnalyzerResults">
		<html>
			<head>
				<title>RoslynAnalyzers Results</title>
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
				<h1>RoslynAnalyzers Results</h1>
				<table style="width:100%">
					<thead>
						<tr>
							<th/>
							<th>Code</th>
							<th>Description</th>
							<th>Location (ascending)</th>
							<th>Project</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="./AnalyzerResult" />
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="AnalyzerResult">
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="@Severity='warning'">
						<img src="../../Assets/StatusWarning.png" alt="warning"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="@Severity" />
					</xsl:otherwise>
				</xsl:choose>
			</td>
			<td>
				<xsl:value-of select="@Code" />
			</td>
			<td>
				<xsl:value-of select="@Description" />
			</td>
			<td>
				<xsl:value-of select="@Location" />
			</td>
			<td>
				<xsl:value-of select="@Project" />
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
