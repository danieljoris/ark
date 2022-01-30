

from domain.value_objects.core.value_object import ValueObject


class Phone(ValueObject):
    number: str
    ddd: str
    country_code: str