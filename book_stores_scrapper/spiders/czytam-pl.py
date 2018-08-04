import scrapy

class CzytamPlSpider(scrapy.Spider):
    name = "czytam-pl"
    start_urls = [
        'https://czytam.pl'
    ]

    #def parse(self, response):
    #   filename = 'czytampl-item.html'
    #   with open(filename, 'wb') as f:
    #      f.write(response.body)
    def parse(self, response):
        # follow links to lists pages
        for a in response.css('li.header-nav-list div div ul li a'):
            yield response.follow(a, self.parse_list)
        
    def parse_list(self, response):
        # follow links to items pages
        for product in response.css('div.product-info h3 a'):
            yield response.follow(product, self.parse_book)

        # follow pagination links
        for page in response.css('div.pagination li a'):
            yield response.follow(page, self.parse_list)

    def parse_book(self, response):
        for div in response.css('div.productreader'):
            yield {
                "title": div.css('div.show-for-medium-up h1::text').extract_first(),
                "author": div.css('div.show-for-medium-up h2.headline-azure a strong::text').extract_first(),
                "price": div.css('div.price strong::text').extract_first(),
                "currency": div.css('div.price strong span::text').extract_first(),
                "params": div.xpath(".//ul[contains(@class, 'parametry')]/li").xpath('normalize-space(string(.))').extract()
            }