<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet 
    version="1.0" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" encoding="UTF-8" indent="yes"/>

    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/University">
        <University>
            <Students>
                <xsl:for-each select="Faculty">
                    <xsl:variable name="facultyName" select="@Name"/>
                    
                    <xsl:for-each select="Department">
                        <xsl:variable name="departmentName" select="@Name"/>
                        
                        <xsl:for-each select="Discipline">
                            <xsl:variable name="disciplineName" select="@Name"/>
                            
                            <xsl:for-each select="Student">
                                <Student>
                                    <ID><xsl:value-of select="@ID"/></ID>
                                    <Name><xsl:value-of select="@Name"/></Name>
                                    <Grade><xsl:value-of select="@Grade"/></Grade>
                                    <Faculty><xsl:value-of select="$facultyName"/></Faculty>
                                    <Department><xsl:value-of select="$departmentName"/></Department>
                                    <Discipline><xsl:value-of select="$disciplineName"/></Discipline>
                                </Student>
                            </xsl:for-each>
                            
                        </xsl:for-each>
                        
                    </xsl:for-each>
                    
                </xsl:for-each>
            </Students>
        </University>
    </xsl:template>

</xsl:stylesheet>
