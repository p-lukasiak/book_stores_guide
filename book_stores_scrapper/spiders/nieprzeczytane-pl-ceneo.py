import scrapy

class NieprzeczytanePlCeneoSpider(scrapy.Spider):
    name = "nieprzeczytane-pl-ceneo"
    start_urls = [
        'https://nieprzeczytane.pl'
    ]

    #def parse(self, response):
    #   filename = 'czytampl-item.html'
    #   with open(filename, 'wb') as f:
    #      f.write(response.body)
    def parse(self, response):
        # follow links to lists pages
        for a in response.xpath("//div[@class='iLeftList']/ul/li/ul/li[contains(@id, 'menu_item')]/a"):
            yield response.follow(a, self.parse_list)
        
    def parse_list(self, response):
        # follow links to items pages
        for producturl in response.css('div.produktListaTytul a::attr(href)').extract():
            yield response.follow(producturl + '?cdn=1', self.parse_book)

        # follow pagination links
        for page in response.css('div.pagerLinks').xpath("./a[@title='»']"):
            yield response.follow(page, self.parse_list)

    def parse_book(self, response):
        for div in response.css('div.produktWlasciwy'):
            yield {
                "title": div.css('div.produktWlasciwyGrupa').css('div.produktWlasciwyTytul h1::text').extract_first(),
                "author": div.css('div.produktWlasciwyGrupa').xpath(".//div[contains(@class, 'produktWlasciwyAutorzy')]/a").xpath('normalize-space(string(.))').extract_first(),
                "price": div.xpath(".//div[@class='produktWlasciwyGrupa2']/span[@itemprop='price']/text()").extract_first(),
                "currency": div.xpath(".//div[@class='produktWlasciwyGrupa2']/span[@itemprop='currency']/text()").extract_first(),
                "params": div.css('div.produktWlasciwyGrupa').xpath(".//div[(@class='produktWlasciwyInfo')]/div").xpath('normalize-space(string(.))').extract()
            }