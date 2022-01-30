

from domain.value_objects.core.value_object import ValueObject


class Address(ValueObject):
    street: str
    number: str
    neighborhood: str
    city: str
    state: str
    country: str