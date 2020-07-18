<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html" version="5" doctype-system="" encoding="utf-8" />
	<xsl:strip-space elements="*" />

	<xsl:template match="DuplicatesReport">
		<html>
			<head>
				<title>R# DupFinder Results</title>
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
				<h1>R# DupFinder summary:</h1>
				<p>
					Codebase cost: <xsl:value-of select="Statistics/CodebaseCost"/>
				</p>
				<p>
					Total duplicates cost: <xsl:value-of select="Statistics/TotalDuplicatesCost"/>
				</p>
				<p>
					Total fragments cost: <xsl:value-of select="Statistics/TotalFragmentsCost" />
				</p>

				<br/>
				<h1>Detected duplicates:</h1>
				<br/>

				<table>
					<thead>
						<tr>
							<th>File</th>
							<th>Lines</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="./Duplicates/Duplicate" />
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="Duplicate">
		<tr style="background-color: #89B0FF;">
			<td colspan="2">
				Duplicate with a cost of <xsl:value-of select="@Cost" />
			</td>
		</tr>

		<xsl:apply-templates select="./Fragment" />
	</xsl:template>

	<xsl:template match="Fragment">
		<tr>
			<td>
				<xsl:value-of select="FileName" />
			</td>
			<td>
				<xsl:value-of select="LineRange/@Start" />-<xsl:value-of select="LineRange/@End" />
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
