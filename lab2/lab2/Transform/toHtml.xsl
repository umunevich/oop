<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
    version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/University">
		<html>
			<head>
				<title>University Information</title>
				<style>
					body {
					font-family: Arial, sans-serif;
					margin: 20px;
					}
					h1 {
					color: #2E4053;
					}
					h2 {
					color: #2874A6;
					}
					h3 {
					color: #1F618D;
					}
					table {
					width: 100%;
					border-collapse: collapse;
					margin-bottom: 20px;
					}
					th, td {
					border: 1px solid #BFC9CA;
					padding: 8px;
					text-align: left;
					}
					th {
					background-color: #AED6F1;
					}
					tr:nth-child(even) {
					background-color: #F2F3F4;
					}
				</style>
			</head>
			<body>
				<h1>University</h1>

				<xsl:for-each select="Faculty">
					<h2>
						Faculty: <xsl:value-of select="@Name"/>
					</h2>

					<xsl:for-each select="Department">
						<h3>
							Department: <xsl:value-of select="@Name"/>
						</h3>

						<xsl:for-each select="Discipline">
							<h4>
								Discipline: <xsl:value-of select="@Name"/>
							</h4>

							<table>
								<tr>
									<th>ID</th>
									<th>Name</th>
									<th>Grade</th>
								</tr>

								<xsl:for-each select="Student">
									<tr>
										<td>
											<xsl:value-of select="@ID"/>
										</td>
										<td>
											<xsl:value-of select="@Name"/>
										</td>
										<td>
											<xsl:value-of select="@Grade"/>
										</td>
									</tr>
								</xsl:for-each>
							</table>

						</xsl:for-each>

					</xsl:for-each>

				</xsl:for-each>

			</body>
		</html>
	</xsl:template>

</xsl:stylesheet>
