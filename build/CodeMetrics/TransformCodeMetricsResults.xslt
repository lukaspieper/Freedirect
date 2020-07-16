<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html" version="5" doctype-system="" encoding="utf-8" />
	<xsl:strip-space elements="*" />

	<xsl:param name="maintainability_index_minimum" />

	<xsl:template match="/">
		<html>
			<head>
				<title>CodeMetrics Results</title>
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
				<h1>CodeMetrics Results</h1>
				<table style="width:100%">
					<thead>
						<tr>
							<th/>
							<th>Name</th>
							<th>MaintainabilityIndex</th>
							<th>CyclomaticComplexity</th>
							<th>ClassCoupling</th>
							<th>DepthOfInheritance</th>
							<th>ExecutableLines</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="CodeMetricsReport/Targets/Target" />
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="Target">
		<tr style="background-color: #89B0FF;">
			<td>
				<img src="../../Assets/CSProjectNode.png" alt="proj"/>
			</td>
			<td>
				<b>
					<xsl:value-of select="@Name" />
				</b>
			</td>
			<xsl:apply-templates select="./Assembly/Metrics" />
		</tr>

		<xsl:apply-templates select="./Assembly/Namespaces/Namespace" />
	</xsl:template>

	<xsl:template match="Namespace">
		<tr style="background-color: #AFAFAF;">
			<td>
				<img src="../../Assets/Namespace.png" alt="namespace"/>
			</td>
			<td>
				<b>
					<xsl:value-of select="@Name" />
				</b>
			</td>
			<xsl:apply-templates select="./Metrics" />
		</tr>

		<xsl:apply-templates select="./Types/NamedType" />
	</xsl:template>

	<xsl:template match="NamedType">
		<tr style="background-color: #E0E0E0;">
			<td>
				<img src="../../Assets/CSFileNode.png" alt="cs"/>
			</td>
			<td>
				<b>
					<xsl:value-of select="@Name" />
				</b>
			</td>
			<xsl:apply-templates select="./Metrics" />
		</tr>

		<xsl:apply-templates select="./Members/Method" />
		<xsl:apply-templates select="./Members/Field" />
		<xsl:apply-templates select="./Members/Property" />
	</xsl:template>

	<xsl:template match="Method">
		<tr>
			<td>
				<img src="../../Assets/Method.png" alt="method"/>
			</td>
			<td>
				<xsl:value-of select="@Name" />
			</td>
			<xsl:apply-templates select="./Metrics" />
		</tr>
	</xsl:template>

	<xsl:template match="Field">
		<tr>
			<td>
				<img src="../../Assets/Field.png" alt="field"/>
			</td>
			<td>
				<xsl:value-of select="@Name" />
			</td>
			<xsl:apply-templates select="./Metrics" />
		</tr>
	</xsl:template>

	<xsl:template match="Property">
		<tr>
			<td>
				<img src="../../Assets/Property.png" alt="property"/>
			</td>
			<td>
				<xsl:value-of select="@Name" />
			</td>
			<xsl:apply-templates select="./Metrics" />
		</tr>
	</xsl:template>

	<xsl:template match="Metrics">
		<xsl:choose>
			<xsl:when test="Metric[@Name='MaintainabilityIndex']/@Value &lt; $maintainability_index_minimum">
				<td bgcolor="#FF221E">
					<xsl:value-of select="Metric[@Name='MaintainabilityIndex']/@Value" />
				</td>
			</xsl:when>
			<xsl:otherwise>
				<td>
					<xsl:value-of select="Metric[@Name='MaintainabilityIndex']/@Value" />
				</td>
			</xsl:otherwise>
		</xsl:choose>

		<td>
			<xsl:value-of select="Metric[@Name='CyclomaticComplexity']/@Value" />
		</td>
		<td>
			<xsl:value-of select="Metric[@Name='ClassCoupling']/@Value" />
		</td>
		<td>
			<xsl:value-of select="Metric[@Name='DepthOfInheritance']/@Value" />
		</td>
		<td>
			<xsl:value-of select="Metric[@Name='ExecutableLines']/@Value" />
		</td>
	</xsl:template>
</xsl:stylesheet>
