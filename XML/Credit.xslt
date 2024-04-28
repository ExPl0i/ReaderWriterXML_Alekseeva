<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns="http://www.credit.darom/credits"
				xmlns:t="http://www.credit.darom/credits"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt"
				exclude-result-prefixes="msxsl">

	<xsl:output method="xml" indent="yes"/>

	<xsl:template match="t:кредиты">
		<данные_о_кредитах>
			<xsl:for-each select="//t:кредит">
				<кредит>
					<!--"Добавление атрибута "id" в элемент "кредит"-->
					<xsl:attribute name="id">
						<xsl:value-of select="@код"/>
					</xsl:attribute>
					<получатель>
						<фио>
							<xsl:value-of select="parent::t:кредит/t:получатель/t:фио"/>
						</фио>
						<пасп_данные>
							<xsl:value-of select="parent::t:кредит/t:получатель/t:пасп_данные"/>
						</пасп_данные>
					</получатель>
					<сумма>
						<xsl:attribute name ="проц_ст">
							<xsl:value-of select="parent::t:сумма/@проц_ст"/>
						</xsl:attribute>
					</сумма>
					<срок>
						<xsl:value-of select="t:срок"/>
					</срок>
				</кредит>
			</xsl:for-each>
		</данные_о_кредитах>
	</xsl:template>
	
</xsl:stylesheet>
				