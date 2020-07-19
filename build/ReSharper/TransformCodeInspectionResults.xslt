<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html" version="5" doctype-system="" encoding="utf-8" />
	<xsl:strip-space elements="*" />
	<xsl:key name="issue_types" match="/Report/IssueTypes/IssueType" use="@Id"/>

	<xsl:template match="Report">
		<html>
			<head>
				<title>R# CodeInspection Results</title>
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
				<h1>R# CodeInspection Results</h1>
				<table style="width:100%">
					<thead>
						<tr>
							<th/>
							<th>Id</th>
							<th>Message</th>
							<th>File</th>
							<th>Line</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="./Issues/Project" />
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="Project">
		<tr style="background-color: #89B0FF;">
			<td>
				<img src="../../Assets/CSProjectNode.png" alt="proj"/>
			</td>
			<td colspan="4">
				<b>
					<xsl:value-of select="@Name" />
				</b>
			</td>
		</tr>

		<xsl:apply-templates select="./Issue" />
	</xsl:template>

	<xsl:template match="Issue">
		<tr>
			<xsl:for-each select="key('issue_types',@TypeId)">
				<td>
					<xsl:choose>
						<xsl:when test="@Severity='WARNING'">
							<img src="../../Assets/StatusWarning.png" alt="WARNING"/>
						</xsl:when>
						<xsl:when test="@Severity='SUGGESTION'">
							<img src="../../Assets/StatusInformation.png" alt="SUGGESTION"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@Severity" />
						</xsl:otherwise>
					</xsl:choose>
				</td>
				<td>
					<xsl:choose>
						<xsl:when test="@WikiUrl">
							<a target="_blank" rel="noopener noreferrer" href="{@WikiUrl}">
								<xsl:value-of select="@Id" />
							</a>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="@Id" />
						</xsl:otherwise>
					</xsl:choose>
				</td>
			</xsl:for-each>

			<td>
				<xsl:value-of select="@Message" />
			</td>
			<td>
				<xsl:value-of select="@File" />
			</td>
			<td>
				<xsl:value-of select="@Line" />
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
